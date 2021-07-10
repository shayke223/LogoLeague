using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoneAfterAnim : MonoBehaviour {

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
