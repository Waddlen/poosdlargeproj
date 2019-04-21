using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour {

	private string record;

	private float StartTime;

	private bool Open = false;

	public GameObject Popup;
	void Start ()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<ShowTime>().record = record;
		StartTime = Time.deltaTime + 1.5f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!Open)
		{
			if(Time.deltaTime >= StartTime)
			{
				Open = true;
				Popup.SetActive(true);
			}
		}	
	}
}
