using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour {

	public GameObject ShadowButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals("Shadow"))
        {
            ShadowButton.GetComponent<Shadow>().DecayBoost = true;
			//ShadowButton.GetComponent<Shadow>().Deactivate();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals("Shadow"))
        {
            ShadowButton.GetComponent<Shadow>().DecayBoost = false;
        }
    }
}
