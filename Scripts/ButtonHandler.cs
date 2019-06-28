using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public Text stageName;
    public StageSelectScript stageSelectScript;
    public StageClearFragScript stageClearFragScript;
    string saveNoString;
    string stageNo;
    int saveClearFlg;

    // Start is called before the first frame update
    void Start()
    {
        //stageSelectScript = GameObject.Find("StageName").GetComponent<StageSelectScript>();
        //stageName.text = stageSelectScript.stageNoText.text;
        saveClearFlg = 0;
        stageNo = stageSelectScript.stageNo.ToString();
        saveNoString = "SaveStage" + stageNo;
        saveClearFlg = PlayerPrefs.GetInt(saveNoString, 0);
    }

    // Update is called once per frame
    void Update()
    {
        saveClearFlg = PlayerPrefs.GetInt(saveNoString, 0);
        if (saveClearFlg == 0)
        {
            stageName.text = "????";
        }   
    }

    public void OnClick()
    {
        //該当するステージNoを取得。セーブしてる場合は格納した値を取得
        saveClearFlg = PlayerPrefs.GetInt(saveNoString);

        if (saveClearFlg == 1)
        {
            //if (stageClearFragScript.stageClearFlg[ stageSelectScript.stageNo - 1 ] == 1) {
            SceneManager.LoadScene(stageName.text);
        }
        //SceneManager.LoadScene("Stage1");
    }
}
