using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour {
    public GameObject YesNoQ;
    public GameObject ClickSound;

    public void PopitUp()
    {
        GameObject snd = Instantiate(ClickSound, transform.position, Quaternion.identity) as GameObject;
        YesNoQ.gameObject.SetActive(true);
    }
}
