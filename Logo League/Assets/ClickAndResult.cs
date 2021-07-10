using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickAndResult : MonoBehaviour {

    public Animator anim;
    public GameObject ClickSound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeMap(int Num)
    {
        
        SceneManager.LoadScene(Num);
    }
    public void AfterClicked(int Num)
    {
        GameObject snd = Instantiate(ClickSound, transform.position, Quaternion.identity) as GameObject;
        if (Num == 1) { anim.SetBool("Clicked", true); }
        if (Num == 2) { anim.SetBool("Clicked2", true); }

    }

    

}
