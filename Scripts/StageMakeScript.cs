using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StageMakeScript : MonoBehaviour {

    public TextAsset textAsset;

    public GameObject player;
    public GameObject frog;
    public GameObject block2;
    public GameObject cherry;
    public GameObject mainCamera;
    GameObject cameraName = null;

    public Vector3 createPos;

    public Vector3 spaceScale = new Vector3(1.0f, 1.0f, 0.0f);

    public string i;

    // Use this for initialization
    void Start () {
        //CreateStage(createPos);
        StartCoroutine(CreateStage(createPos));
        //createPos = Vector2.zero;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator CreateStage(Vector3 pos)
    {
        Vector2 originPos = pos;
        string url = "https://mbaas.api.nifcloud.com/2013-09-01/applications/UJDCR9X2X2OE6xs8/publicFiles/Stage" + i + ".txt";
        UnityWebRequest myWr = UnityWebRequest.Get(url);
        yield return myWr.SendWebRequest();

        string stageTextData = myWr.downloadHandler.text;

        cameraName = Instantiate(mainCamera);
        cameraName.name = mainCamera.name;

        foreach (char c in stageTextData)
        {
            //ベースはblock2
            GameObject obj = block2;

            //ステージobj生成
            if (c == '#')
            {
                obj = Instantiate(block2, pos, Quaternion.identity) as GameObject;
                obj.name = block2.name;
                pos.x += obj.transform.lossyScale.x/3.2f;
            }
            else if (c == 'P')
            {
                obj = Instantiate(player, pos, Quaternion.identity) as GameObject;
                obj.name = player.name;

                //ベースはblock2のため
                obj = block2;

                pos.x += obj.transform.lossyScale.x/3.2f;
            }
            else if (c == 'F')
            {
                pos.y -= 0.5f; 
                obj = Instantiate(frog, pos, Quaternion.identity) as GameObject;
                pos.y += 0.5f;
                obj.name = frog.name;

                //ベースはblock2のため
                obj = block2;

                pos.x += obj.transform.lossyScale.x / 3.2f;
            }
            else if (c == 'c')
            {
                obj = Instantiate(cherry, pos, Quaternion.identity) as GameObject;
                obj.name = cherry.name;

                //ベースはblock2のため
                obj = block2;

                pos.x += obj.transform.lossyScale.x / 3.2f;
            }
            else if (c == '\n')
            {
                //pos.y -= spaceScale.y;
                pos.y -= 1.5625f;
                pos.x = originPos.x;
            }
            else if(c == ' ')
            {
                //pos.x += spaceScale.x;
                pos.x += obj.transform.lossyScale.x / 3.2f;
            }
        }
    }
}
