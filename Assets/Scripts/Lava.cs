using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Lava : MonoBehaviour {

    Rigidbody2D rb;

    public int jumpAmount = 50;
    AudioSource src;
    [SerializeField]
    GameObject lavaParticles;

    // Use this for initialization
    void Start ()
    {
        rb = Player.INSTANCE.gameObject.GetComponent<Rigidbody2D>();
        src = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 avgPos = new Vector3(other.transform.position.x, transform.position.y);

        if(lavaParticles != null)
            Instantiate(lavaParticles, avgPos, Quaternion.identity);

        if(!other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
        else
        {
            if ((Player.health - 10f) > 0)
            {
                src.Play();
            }
            Player.health -= 10;

            Vector3 dir = Vector3.up;
            rb.AddForce((dir * jumpAmount));

        }
    }
}
