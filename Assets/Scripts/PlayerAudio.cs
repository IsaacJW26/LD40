using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{

    AudioSource src;

	// Use this for initialization
	void Start ()
    {
        src = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    public void Play(AudioClip inClip, float pitchRange)
    {
        src.clip = inClip;
        src.pitch = 1f + Random.Range(-pitchRange, pitchRange);
        src.Play();

    }
}
