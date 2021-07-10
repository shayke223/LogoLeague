using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndClose : MonoBehaviour {

    public GameObject[] Close;
    public GameObject[] Open;
    public GameObject ClickSound;

    public void CloseAll()
    {
        for(int i = 0; i < Close.Length; i++)
        {
            Close[i].SetActive(false);
        }
    }
    public void OpenAll()
    {
        for (int i = 0; i < Close.Length; i++)
        {
            Open[i].SetActive(true);
        }
    }
    public void DoBoth()
    {
        GameObject snd = Instantiate(ClickSound, transform.position, Quaternion.identity) as GameObject;
        CloseAll();
        OpenAll();
    }
}
