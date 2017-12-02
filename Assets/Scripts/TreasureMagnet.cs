using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureMagnet : MonoBehaviour
{

    //maximum radius of attraction
    public const float THRESHOLD = 10f;

    public const float magnitude = 10f;
    Rigidbody2D rb;
    Rigidbody2D playerrb;
    Vector3 dir;
    float dist;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        playerrb = Player.INSTANCE.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //distance between player and this
        dist = Vector3.Distance(Player.INSTANCE.transform.position, transform.position);

        //if player is within threshold
        if (dist < THRESHOLD)
        {
            //gets direction vector towards player
            dir = Vector3.Normalize(Player.INSTANCE.transform.position - transform.position);


            //force towards player is mass times magnitude divided by distance
            //further away the player is the weaker the force
            rb.AddForce(dir * magnitude * rb.mass / dist);
            playerrb.AddForce(-dir * magnitude * playerrb.mass / dist);
        }
        else
        {

        }
	}
}
