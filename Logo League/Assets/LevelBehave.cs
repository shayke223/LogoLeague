using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBehave : MonoBehaviour {

    public GameObject Blocker;
    public int StageNumber;
    public int LevelCompleted;
    public Image Bar;
    public Text CompletedText;
    public Text Left;
    public GameManagerObject ManagerObject;

	// Update is called once per frame
	void Start () {
        ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();
        UpdateBar();

    }

    public void UpdateBar()
    {
        float Ratio = LevelCompleted / 20f;
        Bar.rectTransform.localScale = new Vector3(Ratio, 1, 1);
        CompletedText.text = LevelCompleted + "/" + 20;

        Left.text = (16 * StageNumber - ManagerObject.CompletedLevels() +1) + " To Unlock";
    }
}
