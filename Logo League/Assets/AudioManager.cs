using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour {

    public GameManagerObject ManagerObject;
    public Sprite On, Off;
 

    private void Start()
    {
     
        ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();

        if (ManagerObject.Volume == false) { gameObject.GetComponent<Image>().sprite = On; }
        else { gameObject.GetComponent<Image>().sprite = Off; }
    }
    public void AudioTurn()
    {
    
        if (AudioListener.pause == true) { AudioListener.pause = false; ManagerObject.Volume = false; gameObject.GetComponent<Image>().sprite = On; }
        else { AudioListener.pause = true; ManagerObject.Volume = true; gameObject.GetComponent<Image>().sprite = Off; }

   }
}
