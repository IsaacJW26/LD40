using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour {

    [SerializeField]
    public Image im;
    public Text text;

    // Use this for initialization
    void Start () {
        print("hello");
        im.GetComponent<CanvasRenderer>().SetAlpha(0f);
        text.GetComponent<CanvasRenderer>().SetAlpha(0f);
        print(im);
	}
	
	// Update is called once per frame
	void Update () {
        if(Player.health <= 0)
        {
            print("player is dying");
            im.GetComponent<CanvasRenderer>().SetAlpha(im.GetComponent<CanvasRenderer>().GetAlpha() + 0.03f);
            text.GetComponent<CanvasRenderer>().SetAlpha(text.GetComponent<CanvasRenderer>().GetAlpha() + 0.03f);
        }
    }
}
