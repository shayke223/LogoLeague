using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUIText : MonoBehaviour {

    public Text Money;
   
    public GameManagerObject ManagerObject;

	void Start () {
        ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();
        Money.text = "" + ManagerObject.Cash;
    }
	
	public void UpdateMoney () {
        Money.text = "" + ManagerObject.Cash;
    }
}
