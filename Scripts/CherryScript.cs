using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CherryScript : MonoBehaviour {

    public GameObject cherry;

    public CherryCountScript cherryCountScript;

    // Use this for initialization
    void Start () {
        cherryCountScript = GameObject.Find("CherryCount").GetComponent<CherryCountScript>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            // チェリーゲット
            ++cherryCountScript.cherryCount;
            Destroy(cherry);

        }
    }

}
