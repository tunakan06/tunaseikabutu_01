using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CherryCountScript : MonoBehaviour {

    public int cherryCount = 0;
    public Text countText;
    public CherryScript cherryScript;

	// Use this for initialization
	void Start () {
        // チェリーのカウント表示開始
        countText = GetComponent<Text>();
        countText.text = "×　" + cherryCount;
    }
	
	// Update is called once per frame
	void Update () {
        // チェリーのカウント表示
        countText.text = "×　" + cherryCount;
    }
}
