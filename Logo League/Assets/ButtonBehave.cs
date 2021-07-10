using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonBehave : MonoBehaviour {

    public int ButtonLocation;
    Image ButtonImage;
    [SerializeField]
    Text ButtonText;
    public GameObject Blocker;
    public WordArrange TheWord;
    public int ConvertToNum;


    //trY TO PREFAB

    public GameManager GameManager;
    
    void Start () {
        ButtonImage = GetComponent<Image>();

        //trY TO PREFAB
        TheWord = GameObject.Find("The Word").GetComponent<WordArrange>();
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void HideButton()
    {
        //Hide Button and Text
        Color c = ButtonImage.color;
        Color d = ButtonImage.color;
        c.a = 0;
        d.a = 0;
        ButtonImage.color = c;
        ButtonText.color = d;
        Blocker.SetActive(true);
    }
    public void ShowButton()
    {
        Color c = ButtonImage.color;
        Color d = ButtonImage.color;
        c.a = 1;
        d.a = 1;
        ButtonImage.color = c;
        ButtonText.color = d;
        ButtonText.color = new Color32(0, 0, 0, 255); 
        Blocker.SetActive(false);
       // CheckWhosFirst();
    }
    public void CheckWhosFirst()
    {
    
                for (int i = 0; i < TheWord.transform.childCount; i++)
                {
                    if(TheWord.transform.GetChild(i).GetComponent<BoxBehavior>().GoBackTo == 90)
                {
                if (TheWord.transform.GetChild(i).GetComponent<BoxBehavior>().Spacer == false)
                {
                    TheWord.transform.GetChild(i).GetComponent<BoxBehavior>().GoBackTo = ButtonLocation;
                    i = TheWord.transform.childCount;
                }
            }
           }
                
        }

    public void ButtonClicked()
    {
        TheWord.CheckIfEmpty(ConvertToNum);
        GameManager.AddLetter(ConvertToNum);
        GameManager.PlaySound(0);
    }
}
