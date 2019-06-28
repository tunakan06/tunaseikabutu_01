using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour {

    Text txt;
    CherryCountScript cherryCountScript;
    TimeScript timeScript;
    const int CHERRY_MAX_COUNT = 16;
    float flgTime = 16f;
    public PlayerScript playerScript;
    public int playerLife = 1;
    int i;
    public StageClearFragScript stageClearFragScript;
    string saveNoString = "";
    PlayerSoulScript playerSoulScript;

    // Use this for initialization
    void Start () {
        txt = GetComponent<Text>();
        txt.text = "";
        cherryCountScript = GameObject.Find("CherryCount").GetComponent<CherryCountScript>();
        timeScript = GameObject.Find("TimeCount").GetComponent<TimeScript>();
        playerSoulScript = GameObject.Find("PlayerSoul").GetComponent<PlayerSoulScript>();
    }

    // Update is called once per frame
    void Update () {
        // ステージ結果処理
        if (cherryCountScript.cherryCount == CHERRY_MAX_COUNT && timeScript.countTime <= flgTime)
        {
            txt.text = "Stage Cleared";
            if (Input.GetMouseButtonUp(0) == true )
            {
                if (SceneManager.GetActiveScene().name == "Stage1")
                {
                    saveNoString = "SaveStage2";
                    stageClearFragScript.stageClearFlg[1] = 1;
                    PlayerPrefs.SetInt( saveNoString , stageClearFragScript.stageClearFlg[1]);
                    SceneManager.LoadScene("StageSelect");
                }
                else if (SceneManager.GetActiveScene().name == "Stage2")
                {
                    saveNoString = "SaveStage3";
                    stageClearFragScript.stageClearFlg[2] = 1;
                    PlayerPrefs.SetInt(saveNoString, stageClearFragScript.stageClearFlg[2]);
                    SceneManager.LoadScene("StageSelect");
                }
                else if (SceneManager.GetActiveScene().name == "Stage3")
                {
                    stageClearFragScript.stageClearFlg[3] = 1;
                    SceneManager.LoadScene("Title");
                }
            }
        }
        else if (timeScript.countTime > flgTime || playerLife <= 0 || playerScript.transform.position.y < -6.0f)
        {
            if (PlayerPrefs.GetInt("PlayerSoulCountData", playerSoulScript.PlayerSoulCount) > 0)
            {
                txt.text = "Stage Failed...";
            }
            else
            {
                txt.text = "Player Dead...";
            }
            if (Input.GetMouseButtonUp(0) == true)
            {
                //SceneManager.LoadScene("Title");
                if (SceneManager.GetActiveScene().name == "Stage1")
                {
                    if (PlayerPrefs.GetInt("PlayerSoulCountData", playerSoulScript.PlayerSoulCount) > 0)
                    {
                        playerSoulScript.PlayerSoulCount = PlayerPrefs.GetInt("PlayerSoulCountData", playerSoulScript.PlayerSoulCount) - 1;
                        PlayerPrefs.SetInt("PlayerSoulCountData", playerSoulScript.PlayerSoulCount);
                        SceneManager.LoadScene("Stage1");
                    }
                    else
                    {
                        //playerSoulScript.PlayerSoulCount = PlayerPrefs.GetInt("PlayerSoulCountData", playerSoulScript.PlayerSoulCount) + 2;
                        //PlayerPrefs.SetInt("PlayerSoulCountData", playerSoulScript.PlayerSoulCount);
                        SceneManager.LoadScene("Title");
                    }
                }
                else if (SceneManager.GetActiveScene().name == "Stage2")
                {
                    if (PlayerPrefs.GetInt("PlayerSoulCountData", playerSoulScript.PlayerSoulCount) > 0)
                    {
                        playerSoulScript.PlayerSoulCount = PlayerPrefs.GetInt("PlayerSoulCountData", playerSoulScript.PlayerSoulCount) - 1;
                        PlayerPrefs.SetInt("PlayerSoulCountData", playerSoulScript.PlayerSoulCount);
                        SceneManager.LoadScene("Stage2");
                    }
                    else
                    {
                        //playerSoulScript.PlayerSoulCount = PlayerPrefs.GetInt("PlayerSoulCountData", playerSoulScript.PlayerSoulCount) + 2;
                        //PlayerPrefs.SetInt("PlayerSoulCountData", playerSoulScript.PlayerSoulCount);
                        SceneManager.LoadScene("Title");
                    }
                }
                else if (SceneManager.GetActiveScene().name == "Stage3")
                {
                    if (PlayerPrefs.GetInt("PlayerSoulCountData", playerSoulScript.PlayerSoulCount) > 0)
                    {
                        playerSoulScript.PlayerSoulCount = PlayerPrefs.GetInt("PlayerSoulCountData", playerSoulScript.PlayerSoulCount) - 1;
                        PlayerPrefs.SetInt("PlayerSoulCountData", playerSoulScript.PlayerSoulCount);
                        SceneManager.LoadScene("Stage3");
                    }
                    else
                    {
                        //playerSoulScript.PlayerSoulCount = PlayerPrefs.GetInt("PlayerSoulCountData", playerSoulScript.PlayerSoulCount) + 2;
                        //PlayerPrefs.SetInt("PlayerSoulCountData", playerSoulScript.PlayerSoulCount);
                        SceneManager.LoadScene("Title");
                    }
                }
            }
        }
	}
}
