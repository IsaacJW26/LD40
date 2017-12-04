using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

    [SerializeField]
    private float fillAmount1, fillAmount2;

    [SerializeField]
    private Image content1, content2;
    

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        fillAmount1 = Map(Player.health,100);
        fillAmount2 = Map(Player.backpack,200);
        HandleBar();
	}

    private void HandleBar()
    {
        content1.fillAmount = fillAmount1;
        content2.fillAmount = fillAmount2;
    }

    private float Map(float val, float max)
    {
        return val / max;
    }
}
