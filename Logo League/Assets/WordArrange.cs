using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordArrange : MonoBehaviour {

    public int NumberOfChilds;

  //  public Vector2 Space = new Vector2(2, 0);
  //  public RectTransform Pos;

    public int NumberOfSlots;
    public GameObject Space;
    public GameObject BoxSlot;

  
    public GameManager Manager;
    public Transform Self;

    public Transform ChooseLetter;

    public GameObject PrefabObject;

    public LetterBox LB;
    public WordArrange WA;

    public int LocationOnBoard;

  

    void Start () {

        NumberOfSlots = Manager.Word.Length;
        NumberOfChilds = transform.childCount;

        for (int i = 0; i < NumberOfSlots ; i++)
        {
            if (Manager.Letters[i] == 37) { Instantiate(Space, transform.position, Quaternion.identity, Self); }
            else
            {
               GameObject PrefabObject = Instantiate(BoxSlot, transform.position, Quaternion.identity, Self) as GameObject;
                PrefabObject.GetComponent<BoxBehavior>().LetterBoxRef = LB;
                PrefabObject.GetComponent<BoxBehavior>().WordArranger = WA;
                PrefabObject.GetComponent<BoxBehavior>().MyLocation = i;



            }
            }

        //CheckIfEmpty();
    }
	

	void Update () {
       
    }

    public void CheckIfEmpty(int Num)
    {
        
        for (int i = 0; i < NumberOfSlots; i++) {
     
            if (Manager.Letters[i] == 0)
            {
               
                ChooseLetter = transform.GetChild(i);
               // Debug.Log(i+ " is free ");
                i = Manager.Letters.Length;
                ChooseLetter.SendMessage("SelfLettering", Num);
        
            }
    }

    }
    public void CleanTexts()
    {
        if (Manager.UseOfClue == 0)
        {
            for (int i = Manager.UseOfClue; i < NumberOfSlots; i++)
            {

                ChooseLetter = transform.GetChild(i);
                ChooseLetter.SendMessage("ResetChar");
            }
        }
        else CleanTextsClue();
      
    }
    public void CleanTextsClue()
    {
        for (int i = Manager.UseOfClue; i < NumberOfSlots; i++)
        {

            ChooseLetter = transform.GetChild(i);
            ChooseLetter.SendMessage("ResetCharClue");
        }

    }
    public void RemoveChar(int Num)
    {
        Manager.Letters[Num] = 0;
        LB.SendMessage("LettersBack",Num);
    }

}
