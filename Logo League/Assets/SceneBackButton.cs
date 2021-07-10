using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneBackButton : MonoBehaviour {
    public bool ShowAdInScene;
    public int BackToScene;
    public GameManagerObject ManagerObject;
    public bool isPlaying;
    public GameManager Manager;

    private void Start()
    {
        ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();
        
    }
    private void Update()
    {
        if (isPlaying == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                LoadLastLevel();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadLastStage();
        }
    }
    public void LoadLastLevel()
    {
        if (Manager != null)
        {
            ManagerObject.ClueCounters[Manager.CurrentStage, Manager.CurrentLevel] = Manager.UsedClue;
        }
        if (ShowAdInScene)
        {
            if (ManagerObject.CounterForAd % 7 == 0 && ManagerObject.CounterForAd != 0) { ManagerObject.ShowAd1sec(); }
            ManagerObject.CounterForAd++;
        }
        SceneManager.LoadScene(BackToScene);
    }
    public void LoadLastStage()
    {
        if (Manager != null)
        {
            ManagerObject.ClueCounters[Manager.CurrentStage, Manager.CurrentLevel] = Manager.UsedClue;
        }
            if (ShowAdInScene)
        {
            if (ManagerObject.CounterForAd % 7 == 0 && ManagerObject.CounterForAd != 0) { ManagerObject.ShowAd1sec(); }
            ManagerObject.CounterForAd++;
        }
        SceneManager.LoadScene(ManagerObject.WhereToReturn);
    }
}
