using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveDeleteScript : MonoBehaviour
{
    string saveNoString = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        //ステージコンティニューフラグ削除
        for ( int i = 2 ; i < 4; i++) {
            saveNoString = "SaveStage" + i;
            PlayerPrefs.SetInt(saveNoString, 0);
        }
    }
}
