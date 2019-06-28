using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainScript : MonoBehaviour {

    string getSceneName;
    PlayerSoulScript playerSoulScript;

    // Use this for initialization
    void Start () {

        // scene名を取得
        getSceneName = SceneManager.GetActiveScene().name;

	}
	
	// Update is called once per frame
	void Update () {
        // メインステージ遷移
        if (Input.GetMouseButtonUp(0) == true )
        {
            if (getSceneName == "Title")
            {
                PlayerPrefs.SetInt("PlayerSoulCountData", 2);
                SceneManager.LoadScene("StageSelect");
            }
            else if(getSceneName == "StageSelect")
            {
                SceneManager.LoadScene("Stage1");
            }
            else if(getSceneName == "Stage1")
            {
                SceneManager.LoadScene("Stage2");
            }
            else if (getSceneName == "Stage2")
            {
                SceneManager.LoadScene("Stage3");
            }
            else
            {
                SceneManager.LoadScene("Title");
            }
        }
	}
}
