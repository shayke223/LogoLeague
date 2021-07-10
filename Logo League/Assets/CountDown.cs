using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {

    public float Timer;
	// Use this for initialization
	void Start () {
        Destroy(gameObject,Timer*Time.deltaTime*60);
	}

}
