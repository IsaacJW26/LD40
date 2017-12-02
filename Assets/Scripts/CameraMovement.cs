using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 target;
    [SerializeField]
    [Range(1f, 50f)]
    float speed;

	// Use this for initialization
	void Start ()
    {
        target = Vector3.zero;	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        target = transform.position;
        target.x = Player.INSTANCE.transform.position.x;

        transform.position = Vector3.Lerp(transform.position, target, Time.fixedDeltaTime * speed);
	}
}
