using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

    Rigidbody2D rb;

    public int jumpAmount = 50;

    // Use this for initialization
    void Start () {
        rb = Player.INSTANCE.gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject);

        if(!other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
        else
        {
            Player.health -= 10;

            Vector3 dir = new Vector3(0, 50, 0);
            rb.AddForce((dir * jumpAmount));
        }
    }
}
