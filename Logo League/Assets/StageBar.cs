using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageBar : MonoBehaviour {

    public Image Bar;
    public GameManagerObject ManagerObject;
    public Text CompletedText;
    public int CurrentStage;

    private void Start()
    {
        ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();
        UpdateBar();

    }
    public void UpdateBar()
    {
        float Ratio = ManagerObject.LevelComplete[CurrentStage] / 20f;
        Bar.rectTransform.localScale = new Vector3(Ratio, 1, 1);
        CompletedText.text = ManagerObject.LevelComplete[CurrentStage] + "/" + 20;
        if(ManagerObject.LevelComplete[CurrentStage] == 20) { CompletedText.text = "Done"; }
    }
}
