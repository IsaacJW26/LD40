using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = Player.INSTANCE.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject);

        if (other.gameObject.CompareTag("Player"))
        {
            Player.health = 0;
        }
    }
}
