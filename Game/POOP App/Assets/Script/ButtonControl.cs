using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour {

	private bool Active = false;

	public bool ToggleOpen = false;

	public bool ShadowTrigger = false;

	private string trigger = "Player";

	public GameObject WallDoor;

	// Use this for initialization
	void Start ()
	{
		if(ShadowTrigger)
		{
			trigger = "Shadow";
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D(Collider2D col)
    {
		if(col.gameObject.tag.Equals(trigger))
        {
			Active = true;
			WallDoor.GetComponent<DoorController>().OpenDoor(Active);
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(ToggleOpen)
		{
			if(col.gameObject.tag.Equals(trigger))
			{
				Active = false;
				WallDoor.GetComponent<DoorController>().OpenDoor(Active);
			}
		}
	}
}