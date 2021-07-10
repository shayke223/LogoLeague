using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhereToBack : MonoBehaviour {

    public GameManager Manager;
    public GameManagerObject ManagerObject;

	void Start () {
        ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();
    }

    public void GoBack ()
    {
        ManagerObject.PlaySound();
        ManagerObject.ClueCounters[Manager.CurrentStage, Manager.CurrentLevel] = Manager.UsedClue;
        Manager.ChangeMap(ManagerObject.WhereToReturn);
    
    }
}
