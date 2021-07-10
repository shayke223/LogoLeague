using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveLoadHelper : MonoBehaviour {

    public GameManagerObject ManagerObject;

    // This script made to Save and Load the game data!
    void Start () {
        ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();
    }
	

    public void Load()
    {
        ManagerObject.Load();
    }

    public void Save()
    {
        ManagerObject.Save();
    }
    public void ResetGame()
    {
        ManagerObject.ResetGame();
      
    }

}
