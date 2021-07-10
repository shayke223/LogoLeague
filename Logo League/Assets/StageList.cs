using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageList : MonoBehaviour {

    public GameManagerObject ManagerObject;
    public Text TotalLevels;
    
    public int CurrentStage;

  

    void Awake () {

        ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();
        TotalLevels.text = "Total: " + ManagerObject.CompletedLevels() + " / " + ManagerObject.StageRoom.Length * 20;

        OpenStages();
        WhatAvailable();
        SetStagesDetails();

       
    }
    private void Start()
    {
        
        LoadListPos();
    }
    public void WhatAvailable()
    {
        for (int i = CurrentStage; i < transform.childCount; i++)
        {
            if (ManagerObject.StageRoom[i] == false) { transform.GetChild(i).GetComponent<LevelBehave>().Blocker.SetActive(true); }
            else transform.GetChild(i).GetComponent<LevelBehave>().Blocker.SetActive(false);
        }
    }

    public void OpenStages() // If completed level over capacity level can be open
    {
        for (int i = CurrentStage; i < 19; i++)
        {

            if (ManagerObject.CompletedLevels() > 15 + i*16)
            {
                ManagerObject.StageRoom[i+1] = true;
            }
        }
    }
    public void SetStagesDetails()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<LevelBehave>().StageNumber = i;
            transform.GetChild(i).GetComponent<LevelBehave>().LevelCompleted = ManagerObject.LevelComplete[i];
           
        }
    }
    public void SaveListPos()
    {
        ManagerObject.ListPos = transform.localPosition;

    }
    public void LoadListPos()
    {
        transform.localPosition = ManagerObject.ListPos;
    }
}
