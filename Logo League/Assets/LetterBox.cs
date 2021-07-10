using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LetterBox : MonoBehaviour {

    public GameManager Manager;
    public ButtonBehave CurrentButton;
    public GameObject[] LettersPrefab;
    [HideInInspector]
    public string ChosenLetters;
    public GameObject Self;

    void Start () {
        SetLetters();
        SetButtonLocation();
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LettersBack(int Num)
    {

   }
    public void ShowButtons()
    {
   
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<ButtonBehave>().ConvertToNum != 90)
                {
                    transform.GetChild(i).SendMessage("ShowButton");
                }

            }
      
    } 
    public void ShowOneButton(int num)
    {
        transform.GetChild(FindSameLetter(num)).SendMessage("ShowButton");
    }
    public void SetButtonLocation()
    {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).GetComponent<ButtonBehave>().ButtonLocation = i;
          }
    }

    public int FindSameLetter(int Num)
    {
        int Value = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (Num == transform.GetChild(i).GetComponent<ButtonBehave>().ConvertToNum)
            {
                Value = i;
                i = transform.childCount;
            }
            
        }
        return Value;
    }
    public void SetLetters()
    {
        for(int i = 0; i < ChosenLetters.Length; i++)
        {
            int num = Manager.FromLetterToNum(ChosenLetters[i]);
           Instantiate(LettersPrefab[num-1], transform.position, Quaternion.identity, Self.transform);
        }
    }
}
