using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

    [SerializeField]
    private int RotationSpeed = 100;

    [SerializeField]
    private int Movespeed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.back * Time.deltaTime * RotationSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * Movespeed,Space.World);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject);
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            Player.health = 0;
        }
    }
}
