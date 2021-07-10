using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopManager : MonoBehaviour {

    public GameManagerObject ManagerObject;
    public GameManager Manager;

    // public bool[] StagesComplete;
    void Start () {
        ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();
        
	}

    public void ChangeMap(int Num)
    {
        ManagerObject.PlaySound();
        SceneManager.LoadScene(Num);
        
       
    }


}
