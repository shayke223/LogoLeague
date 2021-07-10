using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControll : MonoBehaviour {

    public Animator anim;
    public bool AnimateAfter;
    //public SpriteRenderer SR;
	// Use this for initialization
	void Start () {
        anim = transform.GetComponent<Animator>();
        if (AnimateAfter) { Invoke("PlayAfterInvoke", 20); }

    }


    public void StopAnimation()
    {

        Destroy(GetComponent<SpriteRenderer>());
        Destroy(this);
    }
    public void PlayAfterInvoke()
    {
        anim.Play("AfterInvoke");
    }
}
