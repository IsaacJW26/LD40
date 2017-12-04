using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureMagnet : MonoBehaviour
{

    //maximum radius of attraction
    public const float THRESHOLD = 15f;

    public const float magnitude = 50f;
    Rigidbody2D rb;
    Rigidbody2D playerrb;
    Vector3 dir;
    float dist;

    [Tooltip("Filter for ground check threshhold")]
    public ContactFilter2D filter;

    //distance to float above other colliders
    public const float FLOATTHRESH = 1.9f;

    public float floatSpeed;

    public int treasureValue = 1;

    RaycastHit2D[] results;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        playerrb = Player.INSTANCE.GetComponent<Rigidbody2D>();
        results = new RaycastHit2D[1];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //distance between player and this
        dist = Vector3.Distance(Player.INSTANCE.transform.position, transform.position);

        //if player is within threshold
        if (dist < THRESHOLD && !Player.INSTANCE.IsDead())
        {
            //gets direction vector towards player
            dir = Vector3.Normalize(Player.INSTANCE.transform.position - transform.position);

            //force towards player is mass times magnitude divided by distance
            //further away the player is the weaker the force
            rb.AddForce(dir * magnitude * rb.mass * playerrb.mass / Mathf.Pow(dist, 2f));
            playerrb.AddForce(-dir * magnitude * playerrb.mass * rb.mass / Mathf.Pow(dist, 2f));
        }

        Debug.DrawRay(transform.position, Vector2.down * FLOATTHRESH);

        if (Physics2D.Raycast(transform.position, Vector2.down, filter, results, FLOATTHRESH) > 0)
        {
            rb.AddForce(Vector3.up * floatSpeed);
        }
        //when there is something below
        else
        {
            rb.AddForce(Vector3.down * floatSpeed);
        }
    }
}
