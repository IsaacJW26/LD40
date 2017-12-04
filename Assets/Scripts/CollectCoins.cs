using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    Queue<TreasureMagnet> Treasure;


    // Use this for initialization
    void Start()
    {
        Treasure = new Queue<TreasureMagnet>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<TreasureMagnet>() != null)
        {
            Treasure.Enqueue(col.GetComponent<TreasureMagnet>());
        }
    }

    public Queue<TreasureMagnet> GetTreasure()
    {
        return Treasure;
    }
}
