using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameManagerObject : MonoBehaviour {

    public int Cash,TotalScore,Spins;
    public static GameManagerObject Instance;

    public int HowManyStages = 60;
    public bool[,] Stages;
    public bool[] StageRoom;
    public int[] LevelComplete;
    public int[,] ClueCounters;
    public int CounterForAd;

    public int NextLevel;
    public string NextWord, NextLetters;

    // Information
    public string Word, Letters;
    public int CurrentStage, CurrentLevel;
    public Sprite Logo;
    public Vector2 offset;
    public Vector3 Scale;
    public Color32 BGColor;
    public Vector2 CellsSize;

    public int WhereToReturn;

    public Vector2 ListPos;
    public bool Volume;

    public bool BannerOn;
    public float VolumeValue;

    public GameObject ClickSound;
    public bool CanReward;

    public UpdateUIText2 SpinsText;

    public UpdateUIText MoneysText;

    private void Awake()
    {
        
        BannerOn = false;
    }
    void Start()
    {
        CanReward = false;
        Volume = false;
        VolumeValue = 1;
        HowManyStages = 60;
        Stages = new bool[HowManyStages, 20];
        StageRoom = new bool[HowManyStages];
        LevelComplete = new int[HowManyStages];
        ClueCounters = new int[HowManyStages, 20];

        StageRoom[0] = true;

        LevelComplete = new int[HowManyStages];
      

            if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else DestroyImmediate(gameObject);
        Load();// When Game Ready remove the //!!

    }


    public void Load()
    {

        bool[,] LoadedInfo = SaveManager.LoadPlayerBools();

        for (int i = 0; i < HowManyStages; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                Stages[i, j] = LoadedInfo[i, j];

            }
        }
      
        bool[] LoadedInfo2 = SaveManager.LoadPlayerBools1();
        for (int a = 0; a < HowManyStages; a++)
        {
            StageRoom[a] = LoadedInfo2[a];
        }

        int[] LoadedInfo3 = SaveManager.LoadPlayerInts();
        for (int b = 0; b < HowManyStages; b++)
        {
            LevelComplete[b] = LoadedInfo3[b];
        }

        int[] LoadedInfo4 = SaveManager.LoadPlayerIntsNumbers();
        Cash = LoadedInfo4[0];
        Spins = LoadedInfo4[1];

        int[,] LoadedInfo5 = SaveManager.LoadPlayerClues();

        for (int i = 0; i < HowManyStages; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                ClueCounters[i, j] = LoadedInfo5[i, j];

            }
        }

    }
    public void Save()
    {
        SaveManager.SavePlayer(this);
    }
    public void ResetGame()
    {
   
        //Reset all levels
        for (int i = 0; i < HowManyStages; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                Stages[i, j] = false;

            }
        }

        //Reset Clue Counters.
        for (int i = 0; i < HowManyStages; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                ClueCounters[i, j] = 0;

            }
        }
        //Reset all stages except room 1

        for (int i = 1; i < HowManyStages; i++)
        {
            StageRoom[i] = false;
        }

        for (int i = 0; i < HowManyStages; i++)
        {
            LevelComplete[i] = 0;
        }

        Cash = 0;
        Spins = 0;

      Save();

    }

    public int CompletedLevels()
    {
        int Counter = 0;

        for (int i = 0; i < HowManyStages; i++)
        {
            Counter = Counter + LevelComplete[i];
        }

        return Counter;
         }
    public int CompletedStages()
    {
        int Counter = 0;
        for (int i = 0; i < StageRoom.Length; i++)
        {
            if (StageRoom[i]) { Counter++; }
        }
        return Counter;
    }


    public void ShowAd1sec()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("1Sec", new ShowOptions() { resultCallback = HandleResult1 });
        }
    }
    public void ShowAd5sec()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("video", new ShowOptions() { resultCallback = HandleResult5 });
        }
    }
    public void ShowAd30sec()
    {
        if (Advertisement.IsReady())
        {
            CanReward = false;
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleResult30 });
        }
    }
    public void ShowAd30secForCoins()
    {
        if (Advertisement.IsReady())
        {
            CanReward = false;
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleResult30ForCoin });
        }
    }
    public void HandleResult30(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                if (!CanReward)
                {
                    Spins += 2;
                    CanReward = true;
                    if (SpinsText == null) { SpinsText = GameObject.Find("SpinText").GetComponent<UpdateUIText2>(); }
                    if (SpinsText != null) { SpinsText.UpdateSpins(); }
                    CancelInvoke("CanRewardAgain");
                    Invoke("CanRewardAgain", 0.5f);
                }

                //  Debug.Log("Win30");
                break;
            case ShowResult.Skipped:
                //  Debug.Log("Skip");
                break;
            case ShowResult.Failed:
                //  Debug.Log("Fail");
                break;
        }
    }
    public void HandleResult30ForCoin(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                if (!CanReward)
                {
                    Cash += 600;
                    CanReward = true;
                    if (MoneysText == null) { MoneysText = GameObject.Find("MoneyText").GetComponent<UpdateUIText>(); }
                    if (MoneysText != null) { MoneysText.UpdateMoney(); }
                    CancelInvoke("CanRewardAgain");
                    Invoke("CanRewardAgain", 0.5f);
                }
                //  Debug.Log("Win30");
                break;
            case ShowResult.Skipped:
                //  Debug.Log("Skip");
                break;
            case ShowResult.Failed:
                //  Debug.Log("Fail");
                break;
        }
    }
    public void HandleResult5(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
              //  Debug.Log("Win5");
                break;
            case ShowResult.Skipped:
              //  Debug.Log("Skip");
                break;
            case ShowResult.Failed:
              //  Debug.Log("Fail");
                break;
        }
    }
    public void HandleResult1(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
             //   Debug.Log("Win1");
                break;
            case ShowResult.Skipped:
              //  Debug.Log("Skip");
                break;
            case ShowResult.Failed:
             //   Debug.Log("Fail");
                break;
        }
    }

    public void OpenStages(int Num)
    {
        for (int i = 0; i < Num; i++)
        {

            StageRoom[i] = true;
        }
     }
    public void PlaySound()
    {
       // ClickSound.Play();
      GameObject snd = Instantiate(ClickSound, transform.position, Quaternion.identity) as GameObject;
    }
    public void CanRewardAgain()
    {
        CanReward = false;
    }
}
