using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

    public float countTime = 0;
    public float Timelimit = 16f;
    CherryCountScript cherryCountScript;
    const int CHERRY_MAX_COUNT = 16;

    // Use this for initialization
    void Start () {
        cherryCountScript = GameObject.Find("CherryCount").GetComponent<CherryCountScript>();
    }
	
	// Update is called once per frame
	void Update () {
        //時間カウント
        if (cherryCountScript.cherryCount < CHERRY_MAX_COUNT && Timelimit >= 0) {
            countTime += Time.deltaTime;
            Timelimit = 16f - countTime;
        }
        GetComponent<Text>().text = "Time:" + (int)Timelimit;

    }
}
