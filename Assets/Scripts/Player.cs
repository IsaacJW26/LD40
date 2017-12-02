using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player INSTANCE = null;

	// Use this for initialization
	void Awake ()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
