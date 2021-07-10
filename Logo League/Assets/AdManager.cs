using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour {

    public GameManagerObject ManagerObject;
    public UpdateUIText Money;
    public UpdateUIText2 Spins;
    void Start () {

        ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();

    }


    public void SetAdForSpins()
    {
        ManagerObject.ShowAd30sec();
        Money.UpdateMoney();
        ManagerObject.Save();
    }
    public void SetAdForCoins()
    {
        ManagerObject.ShowAd30secForCoins();
        Spins.UpdateSpins();
        ManagerObject.Save();
    }

}
