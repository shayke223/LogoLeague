using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBG : MonoBehaviour {

    public Vector2 FirstPos;
    public float Speed;
    public Vector2 Destination;
    public float Path;

    public enum side { Left,Right};
    public side Dir;

	void Awake () {
        
        Destination = new Vector2(transform.position.x + (Path*10),transform.position.y);
        FirstPos = transform.localPosition;
       // Debug.Log("FirstPos" + FirstPos);
    }
	
	
	void Update () {
        switch (Dir)
        {
            case side.Left:
                if (transform.localPosition.x < Destination.x)
                {
                    transform.localPosition = FirstPos;
                }
                    break;
            case side.Right:
                if (transform.localPosition.x > Destination.x)
                {
                    transform.localPosition = FirstPos;
                }
                break;
        }

        transform.position = new Vector2(transform.position.x + (Speed * Time.deltaTime),transform.position.y);
	}
}
