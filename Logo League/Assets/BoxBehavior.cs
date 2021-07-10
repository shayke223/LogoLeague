using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxBehavior : MonoBehaviour {
    public bool Spacer;
    public Text MyLetter;

    public LetterBox LetterBoxRef;
    public WordArrange WordArranger;
    public int MyLocation;
    // public LetterBox LetterScript;
    public int GoBackTo;

    public GameManager Manager;
    public GameObject Blocker;

    private string EnglishABC = "-ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789*";
    void Awake () {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
  
    
    }
	
	
	void Update () {
        
    }
    public void SelfLettering(int Number)
    {
        MyLetter.text = EnglishABC[Number].ToString();
        
    }

    public void ResetChar()
    {
 
            //Manager.PlaySound(0);
            MyLetter.text = "";
            GoBackTo = 90;
            if (MyLocation <= Manager.Letters.Length && Spacer == false)
            {
                Manager.Letters[MyLocation] = 0;
            }
            Manager.Blocker.SetActive(false);

    }
    public void ResetCharWithVoice()
    {
        Manager.PlaySound(0);
        MyLetter.text = "";
        GoBackTo = 90;
        if (MyLocation <= Manager.Letters.Length && Spacer == false)
        {
            Manager.Letters[MyLocation] = 0;
        }
        Manager.Blocker.SetActive(false);
    }
    public void ResetCharClue()
    {
        MyLetter.text = "";
        GoBackTo = 90;
        Manager.Blocker.SetActive(false);
    }
    public void RemoveOneChar()
    {
        WordArranger.RemoveChar(MyLocation);
    
    }
    public void GetLetterBack()
    {
        if (GoBackTo != 90)
        {

            LetterBoxRef.transform.GetChild(GoBackTo).GetComponent<ButtonBehave>().ShowButton();
        }
        }

}
