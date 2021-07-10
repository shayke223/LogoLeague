using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private int HowManyWords = 1;
    [HideInInspector]
    public int HowManySpaces;
    public string Word = "Sha*", BottomLetters;
    [HideInInspector]
    public int[] Letters;
    [HideInInspector]
    public char[] ConvertedWord;

    private int CorrectLetters;
    [HideInInspector]
    public char[] AlphaBet ;
    [HideInInspector]
    public string EnglishABC = "-ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789*";
    //private string EnglishABC = "-abcdefghijklmnopqrstuvwxyz*";

    [HideInInspector]
    public GameObject WinMode;
    [HideInInspector]
    public GameObject Blocker;
    public int CurrentStage,CurrentLevel; //Dont forget to change each!

    [HideInInspector]
    public GameManagerObject ManagerObject;
   
    public GameObject SoundWrite,SoundWin;
    [HideInInspector]
    public WordArrange TheWord;
    [HideInInspector]
    public LetterBox AllLetters;
    
    public int UseOfClue, UsedClue;

    private bool Win;

    public GameObject Win20;
    public Text NoteMSG,SpinRT,CoinsRT;


    [HideInInspector]
    public UpdateUIText MoneyText;
    public UpdateUIText2 SpinsText;
    public Text WinModeText;

    public GameObject BGImage;
    //Transfered details
    public Text CurrentLevelText;
    public GameObject Logo;
    public Vector3 Scale;

    public Vector3 offset, TheWordPosition;
    public Color32 BGColor;

    public GridLayoutGroup Layout;

    void Awake()
    {
        
        TheWordPosition = TheWord.transform.position;
        EnglishABC = "-ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789*";
        MoneyText = GameObject.Find("MoneyText").GetComponent<UpdateUIText>();

        ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();

        TakeData();

        AlphaBet = new char[EnglishABC.Length];
        SetEnglishChars();

        AllCommands();
        SetSpaces();
        if (ManagerObject.Stages[CurrentStage, CurrentLevel] == true) { WinMode.SetActive(true); Win = true; WinModeText.text = Word; }
        WinModeText.text = NoSpacesWord();

        AllLetters.ChosenLetters = BottomLetters;

    }
    public void Start()
    {
        if (ManagerObject.ClueCounters[CurrentStage, CurrentLevel] > 0)
        {
            Invoke("AlreadyClue", 0.01f);
        }
    }
    public void UpdateNumberOfLetters()
    {
        Letters = new int[Word.Length + HowManyWords-1]; // Set Player's Letter array

    }
    public void AddLetter(int Letter)
    {

        for (int i = 0; i < Word.Length; i++)
        {
            if (ConvertedWord[i] != '*') // Revah
            {
                if (Letters[i] == 0)
                {
                    Letters[i] = Letter;
                    i = Word.Length;
                }
            }
        }
       // PlaySound(0);
        CheckIfWin();
    }

    public void CheckIfWin()
    {
        if (!Win)
        {
            CorrectLetters = 0;
            for (int i = 0; i < ConvertedWord.Length; i++)
            {
                if (ConvertedWord[i] == AlphaBet[Letters[i]])
                {
                    CorrectLetters += 1;

                }
            }
            if (CorrectLetters == Word.Length)
            {
                PlaySound(1);
                WinMode.SetActive(true);
                ManagerObject.Stages[CurrentStage, CurrentLevel] = true;
                ManagerObject.LevelComplete[CurrentStage]++;
                ManagerObject.Cash += 100;
                ManagerObject.Save();
                MoneyText.UpdateMoney();
                Win = true;
                if(ManagerObject.LevelComplete[CurrentStage] == 20) { MSGReward("You have completed all 20 Levels ", 1, 1000); }
                if ((ManagerObject.CompletedStages()) * 16 == ManagerObject.CompletedLevels() ) { MSGReward("New stage available", 1, 1000);  }
              
            }
            BlockClickingIfFull();
        }

    }
    public void ConvertWordToNum()
    {

        // Cant use Char with Button so i used Array that 1 = 'a'.
        // ConvertedWord is an array that take the String "Shay" and make him 's' 'h' 'a' 'y';
        ConvertedWord = new char[Word.Length];
        for (int i = 0; i < Word.Length; i++)
        {
            ConvertedWord[i] = Word[i];
        }

     }
    public void SetEnglishChars()
    {

        for (int i = 0; i < EnglishABC.Length; i++)
        {
            AlphaBet[i] = EnglishABC[i];
        }

    }
    public void RestartLetters()
    {
     
        for (int i = UseOfClue ; i < Letters.Length; i++)
        {
            Letters[i] = 0;

        }
        SetSpaces();
        BlockClickingIfFull();
    }
    public void SetSpaces()
    {
        HowManySpaces = 0;
        for (int i = 0; i < Letters.Length; i++)
        {
            if (ConvertedWord[i] == '*')
            {
                Letters[i] = 37;
                HowManySpaces++;
            }

      }
    }
    public void CountWords()
    {
        HowManyWords = 0;
        for (int i = 0; i < ConvertedWord.Length; i++)
        {
            if(ConvertedWord[i] == '*')
            {
                HowManyWords++;
            }
        }
        if(HowManyWords == 0) { HowManyWords = 1 ; }
    }
    public void AllCommands()
    {

        UpdateNumberOfLetters();

        for (int i = 0; i < Word.Length; i++)
        {
            Letters[i] = 0;

        }
        ConvertWordToNum();
        CountWords();
       
      
    }
  public void BlockClickingIfFull()
    {
        int Counter = 0;
        for (int i = 0; i < Letters.Length; i++)
        {

            if (Letters[i] != 0)
            {
                Counter++;
            }

        }
        if(Counter == Letters.Length) { Blocker.SetActive(true); }
    }
    public void ChangeMap(int Num)
    {
        if (ManagerObject.CounterForAd % 7 == 0 && ManagerObject.CounterForAd != 0) { ManagerObject.ShowAd1sec(); }
        ManagerObject.CounterForAd++;
        SceneManager.LoadScene(Num);
    }

    public void PlaySound(int num)
    {
        if (num == 0) { GameObject snd = Instantiate(SoundWrite, transform.position, Quaternion.identity) as GameObject; }
        if (num == 1) { GameObject snd2 = Instantiate(SoundWin, transform.position, Quaternion.identity) as GameObject; }

    }
    public void UseClue()
    {
       
           RestartLetters();
           TheWord.CleanTextsClue();
           AllLetters.ShowButtons();

        if (!Win)
        {
            if (ManagerObject.Cash >= 0)
            {
                if (UseOfClue - HowManySpaces <= Letters.Length)
                {
                    while (Recursion(UseOfClue) == 1)
                    {
                        UseOfClue++;
                    }

                    if (Letters[UseOfClue] != 0) { AllLetters.ShowOneButton(Letters[UseOfClue]); }

                    Letters[UseOfClue] = FromLetterToNum(ConvertedWord[UseOfClue]);
                  //  AllLetters.LettersBack(UseOfClue);
                    TheWord.transform.GetChild(UseOfClue).transform.GetChild(0).GetComponent<Text>().text = "" + ConvertedWord[UseOfClue]; //Change the LEtter of the world
                   
                    UseOfClue++;
                }
             //   CheckIfWin();
              //  ManagerObject.Cash -= 20;
                MoneyText.UpdateMoney();
                for (int i = 0; i < AllLetters.transform.childCount; i++)
                {

                    if (AllLetters.transform.GetChild(i).GetComponent<ButtonBehave>().ConvertToNum == FromLetterToNum(ConvertedWord[UseOfClue-1])) 
                    {
                        AllLetters.transform.GetChild(i).GetComponent<ButtonBehave>().HideButton();
                        AllLetters.transform.GetChild(i).GetComponent<ButtonBehave>().ConvertToNum = 90;
                        TheWord.GetComponent<WordArrange>().transform.GetChild(UseOfClue-1).GetComponent<BoxBehavior>().Blocker.SetActive(true);
                        i = AllLetters.transform.childCount;


                    }

                }

                UsedClue++;
                
         
                CheckIfWin();
            }
        }
        
   
    }

    public int FromLetterToNum(char TheLetter)
    {
        int ReturnNumber = 0;
        for(int i =0; i < EnglishABC.Length; i++)
        {
            if(TheLetter == EnglishABC[i]) { ReturnNumber = i; i = EnglishABC.Length; }
        }
        return ReturnNumber;

    }

    public int Recursion(int num)
    {
        if (Letters[num] == 37)
        {
            return 1;
        }
        else return 0;
  
    }
    public void UseOneLetterClue()
    {
      if(ManagerObject.Cash >= 300) {
        UseClue();
   
        PlaySound(0);
        ManagerObject.Save();
        ManagerObject.ClueCounters[CurrentStage,CurrentLevel] = UsedClue+1;
        FinishClue();
        ManagerObject.Cash -= 300;
            MoneyText.UpdateMoney();
        }
    }
    public void UseClueFull()
    {
        if (ManagerObject.Cash >= 3000)
       {
            for (int i = UsedClue; i < Letters.Length - HowManySpaces; i++)
            {
                UseClue();
            }
        FinishClue();
            ManagerObject.Cash -= 3000;
            MoneyText.UpdateMoney();
        }
    }
   public string NoSpacesWord()
    {
        string NewWord ="";
        /*
                for(int i = 0; i < Word.Length; i++)
                {
                    if(Word[i] == '*') { Word.Remove(i); Word.Insert(i,"^"); }
                }
                */

        NewWord = Word.Replace('*', ' '); // Replace * with space
        return NewWord;
    }
    public void TakeData()
    {
        Word = ManagerObject.Word;
        BottomLetters = ManagerObject.Letters;
        CurrentLevel = ManagerObject.CurrentLevel;
        CurrentStage = ManagerObject.CurrentStage;
        CurrentLevelText.text = "Level " + (CurrentLevel+1);
        Logo.gameObject.GetComponent<Image>().sprite = ManagerObject.Logo;
        offset = ManagerObject.offset;
        TheWord.transform.position = TheWordPosition +  offset;
        Scale = ManagerObject.Scale;
        Logo.transform.localScale = Scale;
        BGColor = ManagerObject.BGColor;
        BGImage.GetComponent<Image>().color = BGColor;
        Layout.cellSize = ManagerObject.CellsSize;
    }
    public void MSGReward(string msg,int SpinR,int CoinR)
    {
        Win20.SetActive(true);
        NoteMSG.text = msg;
        SpinRT.text = SpinR.ToString();
        CoinsRT.text = CoinR.ToString();
        ManagerObject.Spins += SpinR;
        ManagerObject.Cash += CoinR;
        ManagerObject.Save();
        MoneyText.UpdateMoney();
        SpinsText.UpdateSpins();

    }

    public void FinishClue() // Have to use different to optimize
    {
        //All of those commands made to be able to give back the letter!
        AllLetters.transform.GetChild(0).GetComponent<ButtonBehave>().HideButton();
        TheWord.CheckIfEmpty(0);
        AddLetter(0);
        AllLetters.transform.GetChild(0).GetComponent<ButtonBehave>().CheckWhosFirst();
        RestartLetters();
        TheWord.CleanTexts();
        AllLetters.ShowButtons();
    }
    public void AlreadyClue()
    {
        if (!Win)
        {
                for (int i = 0; i < ManagerObject.ClueCounters[CurrentStage, CurrentLevel]; i++)
                {
                    UseClue();
                FinishClue();
            }
               //FinishClue();
            }
        Debug.Log(ManagerObject.ClueCounters[CurrentStage, CurrentLevel]);
    }   
 
}