using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	public GameObject Door;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenDoor(bool active)
	{
		if(active)
		{
			Door.SetActive(false);
		}
		else
		{
			Door.SetActive(true);
		}
	}
}
