using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static float health = 100f;
    public static float backpack = 0;

    public static Player INSTANCE = null;


    public AudioClip deathClip;
    public GameObject deathParticles;

    bool isDead;

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
        health = 100f;

        isDead = false;
	}
	
	void Update ()
    {
		if (health <= 0 && !isDead)
        {
            isDead = true;
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            GameManager.INSTANCE.RestartLevel();

            gameObject.SetActive(false);
        }
	}

    public bool IsDead()
    {
        return isDead;
    }
}
