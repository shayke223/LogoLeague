using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AllData : MonoBehaviour {

    public Data[] Datas;
    public GameManagerObject ManagerObject;
    public int CurrentStage;

    private void Start()
    {
        ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();
        ManagerObject.WhereToReturn = CurrentStage;
    }
    public void MoveData(int Num)
    {
        ManagerObject.CurrentLevel = Datas[Num].CurrentLevel;
        ManagerObject.CurrentStage = Datas[Num].CurrentStage;
        ManagerObject.Word = Datas[Num].Word;
        ManagerObject.Letters = Datas[Num].Letters;
        ManagerObject.Logo = Datas[Num].Logo;
        ManagerObject.offset = Datas[Num].offset;
        ManagerObject.Scale = Datas[Num].Scale;
        ManagerObject.BGColor = Datas[Num].BGColor;
        ManagerObject.CellsSize = Datas[Num].CellsSize;
        
   
    }
}
