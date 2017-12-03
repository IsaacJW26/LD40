using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureMagnet : MonoBehaviour
{

    //maximum radius of attraction
    public const float THRESHOLD = 20f;

    public const float magnitude = 15f;
    Rigidbody2D rb;
    Rigidbody2D playerrb;
    Vector3 dir;
    float dist;

    [Tooltip("Filter for ground check threshhold")]
    public ContactFilter2D filter;

    //distance to float above other colliders
    public const float FLOATTHRESH = 1.5f;

    public float floatSpeed;

    RaycastHit2D[] results;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        playerrb = Player.INSTANCE.GetComponent<Rigidbody2D>();
        results = new RaycastHit2D[1];
    }

    // Update is called once per frame
    void FixedUpdate ()
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
            rb.AddForce(dir * magnitude * rb.mass * playerrb.mass / Mathf.Pow(dist, 2f));
            playerrb.AddForce(-dir * magnitude * playerrb.mass * rb.mass / Mathf.Pow(dist, 2f));
        }
        //when it is out of range of player
        //{
            Debug.DrawRay(transform.position, Vector2.down * FLOATTHRESH);

            //when there is nothing below
            if (Physics2D.Raycast(transform.position, Vector2.down, filter, results, FLOATTHRESH) > 0)
            {
                rb.AddForce(Vector3.up * floatSpeed);
            }
            //when there is something below
            else
            {
                rb.AddForce(Vector3.down * floatSpeed);
            }
        //}
	}
}
