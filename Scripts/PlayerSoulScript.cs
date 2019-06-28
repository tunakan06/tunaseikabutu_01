using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSoulScript : MonoBehaviour {

    public int PlayerSoulCount;

    // Use this for initialization
    void Start () {
        //cherryCountScript = GameObject.Find("CherryCount").GetComponent<CherryCountScript>();
    }
	
	// Update is called once per frame
	void Update () {
        
        GetComponent<Text>().text = "x " + PlayerPrefs.GetInt("PlayerSoulCountData", PlayerSoulCount);

    }
}
