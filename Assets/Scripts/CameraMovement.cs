using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 target;

	// Use this for initialization
	void Start ()
    {
        target = Vector3.zero;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        target = transform.position;
        target.x = Player.INSTANCE.transform.position.x;

        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
	}
}
