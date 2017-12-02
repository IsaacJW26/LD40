using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 1f;

    [Header("Jumping")]
    public float jumpStrength;
    public float jumpCD;
    [Tooltip("Minimun distance between object and player")]
    public float distance;

    float jumpStart;

    Rigidbody2D rb;


    public ContactFilter2D filter;

    Rigidbody2D hitrb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpStart = -jumpCD;

    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);



        if (Input.GetButtonDown("Jump") && jumpStart < Time.time && canJump(out hitrb))
        {
            Vector3 dir = new Vector3(0, jumpStrength, 0);

            jumpStart = Time.time + jumpCD;
            rb.AddForce((dir * moveSpeed));
            if (hitrb != null)
            {
                hitrb.AddForce((-dir * moveSpeed) * hitrb.mass);
            }

        }
    }

    //60 times a second
    void FixedUpdate()
    {
        //horizontal motion
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        rb.AddForce((dir * moveSpeed));


    }


    bool canJump(out Rigidbody2D hit)
    {
        bool jump = false;
        hit = null;

        RaycastHit2D[] results = new RaycastHit2D[10];
        if (Physics2D.Raycast(transform.position, Vector2.down, filter, results, distance) > 0)
        {
            jump = true;
            hit = results[0].collider.GetComponentInParent<Rigidbody2D>();
        }

        return jump;
    }
}
