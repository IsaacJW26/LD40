using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float maxSpeed = 10f;

    [Header("Jumping")]
    public float jumpStrength;
    public float jumpCD;
    [Tooltip("Minimun distance between object and player")]
    public float distance;
    public AudioClip jumpAudio;

    float jumpStart;

    [Header("Reset Rotation")]
    public float rotationSpeed;
    public const float ROT_THRESH = 15f;
    public const float ROT_SPEED_THRESH = 200f;

    Rigidbody2D rb;

    public ContactFilter2D filter;

    Rigidbody2D hitrb;
    SpriteRenderer sprite;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpStart = -jumpCD;
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);

        //jump
        if (Input.GetButtonDown("Jump") && jumpStart < Time.time && canJump(out hitrb))
        {
            Vector3 dir = new Vector3(0, jumpStrength, 0);
            GetComponent<PlayerAudio>().Play(jumpAudio, 0.1f);
            jumpStart = Time.time + jumpCD;
            rb.AddForce((dir));
            if (hitrb != null)
            {
                hitrb.AddForce((-dir) * hitrb.mass);
            }
        }

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.01f)
        {
            anim.SetBool("isRunning", true);
            if (Input.GetAxis("Horizontal") < 0f)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    //60 times a second
    void FixedUpdate()
    {
        //horizontal motion
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        //Only accelerate if velocity is less than max speed
        if (Mathf.Abs(rb.velocity.x) < maxSpeed)
        {
            rb.AddForce(dir * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            dir.x = -Mathf.Sign(rb.velocity.x);
            rb.AddForce(dir * moveSpeed * Time.fixedDeltaTime);
        }

        //reset rotation of player when knocked over
        if (transform.eulerAngles.z > ROT_THRESH && transform.eulerAngles.z < 360f - ROT_THRESH)
        {
            float rotationAmount = 0;
            //rotate towards upright position with decreasing speeds
            if ((transform.eulerAngles.z) < 180f)
            {
                rotationAmount = Mathf.Abs(transform.eulerAngles.z / 180f);
                if (rb.angularVelocity > rotationAmount * -ROT_SPEED_THRESH)
                {
                    rb.AddTorque(-rotationSpeed * rotationAmount);
                }
            }
            else
            {
                rotationAmount = Mathf.Abs((360f - transform.eulerAngles.z) / 180f);

                if (rb.angularVelocity < rotationAmount * ROT_SPEED_THRESH)
                {
                    rb.AddTorque(rotationSpeed * rotationAmount);
                }
            }
        }
    }


    bool canJump(out Rigidbody2D hit)
    {
        bool jump = false;
        hit = null;

        RaycastHit2D[] results = new RaycastHit2D[1];
        if (Physics2D.Raycast(transform.position, Vector2.down, filter, results, distance) > 0)
        {
            jump = true;
            hit = results[0].collider.GetComponentInParent<Rigidbody2D>();
        }

        return jump;
    }
}