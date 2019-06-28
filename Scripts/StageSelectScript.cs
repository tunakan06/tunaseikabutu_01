using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectScript : MonoBehaviour
{
    public Text stageNoText;
    public int stageNo;

    // Start is called before the first frame update
    void Start()
    {
        // ステージナンバーを取得
        stageNoText = GetComponent<Text>();
        //stageNoText.text = "";
        stageNoText.text = "Stage" + stageNo;
    }

    // Update is called once per frame
    void Update()
    {
        
        //stageNoText.text = "Stage" + stageNo;
    }

}
