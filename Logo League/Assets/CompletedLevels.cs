using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedLevels : MonoBehaviour {

    public int CurrentStage;
    public GameManagerObject ManagerObject;
   
	void Start () {
        ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();
        CheckLevelsComplete();
    }

    public void CheckLevelsComplete()
    {
        for (int i = 0; i < 20; i++)
        {
           if( ManagerObject.Stages[CurrentStage, i] == true)
            {
                transform.GetChild(i).GetComponent<LevelSelect>().Blocker.SetActive(true);
            }
        }
    }
}
