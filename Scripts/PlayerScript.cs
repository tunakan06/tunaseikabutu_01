using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float speed = 4500.0f;
    Animator animator;
    Vector3 scale;
    GameObject mainCamera;
    new Collider2D collider2D;
    CherryCountScript cherryCountScript;
    TimeScript timeScript;
    float flgTime = 16f;
    ResultScript resultScript;
    new Rigidbody2D rigidbody2D;
    public float flap = 1200.0f;
    private bool isGrounded; //着地判定
    private bool isSideCol; //横衝突判定
    public LayerMask groundLayer; //Linecastで判定するLayer

    float A; // 加速度
    float posY; // Y座標
    float JUMPPOWER; // 加速度
    float G; // 重力

    float B;

    int i;

    enum Status{

        ground,
        jump,
        fall

    }

    Status status = Status.ground;
    const int CHERRY_MAX_COUNT = 16;

    // Use this for initialization
    void Start () {

        A = 0.0f; // 加速度
        posY = 0.0f; // Y座標
        JUMPPOWER = 0.98f * 6.0f / 8.0f; // 加速度
        G = 0.98f / 12.0f; // 重力

        B = 0.0f;

        i = 0;

        collider2D = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        cherryCountScript = GameObject.Find("CherryCount").GetComponent<CherryCountScript>();
        timeScript = GameObject.Find("TimeCount").GetComponent<TimeScript>();
        mainCamera = GameObject.FindWithTag("MainCamera");
        resultScript = GameObject.Find("Text").GetComponent<ResultScript>();

        animator.SetBool("idle", true);
        animator.SetBool("run", false);

        this.rigidbody2D = GetComponent<Rigidbody2D>();
        A = JUMPPOWER;

    }
	
	// Update is called once per frame
	void Update () {

        PlayerAction();

    }

    private void FixedUpdate()
    {

        bool x = Input.GetMouseButton(0);

        // 画面移動
        if (!x)
        {
            // カメラ移動処理
            if ((transform.position.x > mainCamera.transform.position.x - 4) & (transform.position.x <= mainCamera.transform.position.x - 8))
            {
                Vector3 cameraPos = mainCamera.transform.position;
                cameraPos.x = transform.position.x + 4;
                mainCamera.transform.position = cameraPos;
            }
            else if (transform.position.x > mainCamera.transform.position.x -8)
            {
                Vector3 cameraPos = mainCamera.transform.position;
                cameraPos.x = transform.position.x - 4;
                mainCamera.transform.position = cameraPos;
            }

        }

    }

    // ジャンプ中
    float jump()
    {
        A -= G;
        //PosY += Acc;

        //if (PosY < 0.0f) // 0.0は地面
        if(A < 0.0f)
        {
            // 着地
            A = 0.0f;
        }

        return A;

    }

    void PlayerAction()
    {
        isGrounded = Physics2D.Linecast(
            transform.position,
            transform.position - transform.up * 0.8f,
            groundLayer);

        isSideCol = Physics2D.Linecast(
            transform.position,
            transform.position + transform.right * 0.5f,
            groundLayer);

        //右・左
        bool x = false;
        if (cherryCountScript.cherryCount < CHERRY_MAX_COUNT && timeScript.countTime <= flgTime && resultScript.playerLife > 0 && transform.position.y >= -6.0f)
        {
            x = true;
        }

        bool y = false;

        if (transform.position.y <= 0 || status == Status.jump)
        {

            //上・下
            if (timeScript.countTime <= flgTime && resultScript.playerLife > 0 && transform.position.y >= -6.0f)
            {
                y = Input.GetMouseButton(0);
            }
            if (status == Status.ground)
            {
                status = Status.jump;
            }

        }
        else if (transform.position.y > 0 || status == Status.fall)
        {
            y = false;
            if (status == Status.jump)
            {
                status = Status.fall;
            }

        }
        else if (status == Status.fall && collider2D.tag == "block")
        {
            status = Status.ground;
        }

        scale = transform.localScale;

        //アニメーション分岐
        if (x)
        {
            animator.SetBool("idle", false);
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("idle", true);
            animator.SetBool("run", false);
        }

        //キャラクター反転
        if (x == true)
        {
            //右向き
            scale.x = 4;
        }
        else if (x == false)
        {
            //左向き(反転)
            scale.x = -4;
        }
        //代入しなおす
        transform.localScale = scale;

        float a, b;
        if (x == true)
        {
            a = 45.0f/60.0f;
        }
        else
        {
            a = 0.0f;
        }

        //Debug.Log(y && isGrounded);
        Debug.Log(isSideCol && !isGrounded);

        i += 1;

        if (Input.GetMouseButton(0) == true && isGrounded && ((10 *i) % 65 == 0))
        {
            b = 0.0f;
            //a = 0.0f;
            a = 10.0f / 60.0f;

            // 速度をクリアした2回目のジャンプも1回目と同じ挙動にする。 
            rigidbody2D.velocity = Vector2.zero;

            //rigidbody2D.AddForce(5.0f * new Vector2( 0.3f ,1.0f) * flap * 0.9f);
            //rigidbody2D.AddForce(5.0f * new Vector2(0.0f, jump()) * flap *1.4f);
            rigidbody2D.AddForce(5.2f * Vector2.up * jump() * flap * 1.4f);

            isGrounded = false;

        }
        else if (isSideCol && !isGrounded)
        {
            b = 0.0f;
            rigidbody2D.velocity = Vector2.zero;

            rigidbody2D.AddForce(5.0f * new Vector2(0, -G) * flap);
        }
        else
        {
            b = 0.0f;
        }

        //移動する向きを決める
        Vector2 direction = new Vector2(a, b);

        //移動する向きとスピードを代入する
        GetComponent<Rigidbody2D>().velocity = 2.1f * direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("block"))
        {
            isGrounded = true;
        } 
    }
}
