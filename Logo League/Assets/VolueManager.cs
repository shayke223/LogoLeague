using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolueManager : MonoBehaviour {

    public Slider Slider;
    public GameManagerObject ManagerObject;


    private void Start()
    {
        ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();
        Slider.value = ManagerObject.VolumeValue;
        Slider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    public void ChangeVolume()
    {
        AudioListener.volume = Slider.value;
        ManagerObject.VolumeValue = Slider.value;
    }
}
