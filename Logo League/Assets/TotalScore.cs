using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour {

    public GameManagerObject ManagerObject;
    public Text Self;

    void Start () {
    
            ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();
        UpdateNum();
        }

    public void UpdateNum()
    {
        Self.text = ManagerObject.CompletedLevels() + "/" + "420";
    }
}
