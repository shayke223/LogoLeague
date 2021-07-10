using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateUIText2 : MonoBehaviour {

    public GameManagerObject ManagerObject;
    public Text SpinText; 
        
	void Start () {
        ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();
        SpinText.text = "" + ManagerObject.Spins;
    }


    public void UpdateSpins()
    {
        SpinText.text = "" + ManagerObject.Spins;
    }
}
