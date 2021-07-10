using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Developer : MonoBehaviour {

    public GameManagerObject ManagerObject;
	void Start () {
        ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();
    }
	
    public void OpenAll()
    {
        ManagerObject.OpenStages(ManagerObject.StageRoom.Length);
        ManagerObject.Cash += 10000;
        ManagerObject.Spins += 10;
    }
}
