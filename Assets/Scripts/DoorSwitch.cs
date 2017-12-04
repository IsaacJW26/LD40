using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour {

    private int DoorClosed = 0;
    private float distance = 0;
    private bool next = true;
    private int treasureCount = 0;
    private int coinIndex = 0;
    private int totalCoins = 0;

	// Use this for initialization
	void Start () {
        //print("cutoff:" + transform.parent.position.x);
        totalCoins = GameObject.Find("coins").transform.childCount;

    }
	
	// Update is called once per frame
	void Update () {
        //close the door  behind you!
		if (DoorClosed == 1)
        {

            distance += Time.deltaTime * 2;
            if (distance <= 4)
            {
                this.transform.parent.GetChild(1).Translate(Vector3.down * Time.deltaTime * 2);
            }
            else
            {
                DoorClosed = 2;
            }
        }

        //count up all the treasures u collected
        if (DoorClosed == 2)
        {
            Transform child;
            if (coinIndex < totalCoins)
            {
                child = GameObject.Find("coins").transform.GetChild(coinIndex);
                //print(child.position.x);
                if (child.position.x >= transform.parent.position.x)
                {

                    Destroy(child.gameObject);
                    treasureCount++;
                    totalCoins--;

                }
                else
                {
                    coinIndex++;
                }
            }
            //show the result!!
            else
            {
                DoorClosed = 3;
                print("total coins earned: " + treasureCount);
            }
        }

	}

    //pull the lever cronk
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            print(this.transform.parent.GetChild(1).gameObject.name);
            DoorClosed = 1;
        }
    }
}
