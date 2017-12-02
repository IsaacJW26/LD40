using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static float health = 100;
    public static float backpack = 0;

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
	void Update ()
    {
		if (health <= 0)
        {
            //die
        }
	}
}
