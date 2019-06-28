using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour {

    public float speed;

    public ResultScript resultScript;
    PlayerScript playerScript;
    float jumpPower = 0.8f;
    float jumpGravity = 0.05f;

    // Use this for initialization
    void Start () {
        resultScript = GameObject.Find("Text").GetComponent<ResultScript>();
        playerScript = GameObject.Find("player").GetComponent<PlayerScript>();
    }
	
	// Update is called once per frame
	void Update () {

        // カエルの突撃
        if ( transform.position.x - playerScript.transform.position.x < 2.5f)
        {
            if (jumpPower >= 0f)
            {
                jumpPower = jumpPower - jumpGravity;
            }
            else
            {
                //jumpPower = jumpGravity - jumpPower;
            }
            FrogJump(jumpPower);
        }

	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            // フロッグエネミーと接触→ライフ減る
            resultScript.playerLife = resultScript.playerLife - 1;

        }
    }

    void FrogJump(float jumpPower)
    {
        Vector3 vec;
        vec.x = -1.0f;
        vec.y = 0.0f;
        vec.z = 0.0f;

        transform.Translate(vec * jumpPower);
    }

}
