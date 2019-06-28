using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearFragScript : MonoBehaviour
{
    public int[] stageClearFlg;
    string saveNoString = "";

    // Start is called before the first frame update
    void Start()
    {
        saveNoString = "SaveStage1";
        stageClearFlg = new int[] { 0, 0, 0, 0 };
        stageClearFlg[0] = 1;
        PlayerPrefs.SetInt(saveNoString, stageClearFlg[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
