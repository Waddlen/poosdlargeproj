using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour {

	//private string record;

	public Text record;

	public GameObject Popup;
	void Start ()
	{
		//GameObject.FindGameObjectWithTag("Player").GetComponent<ShowTime>().record = record;
		Popup.SetActive(true);


		GameObject[] Timers = GameObject.FindGameObjectsWithTag("Timer");
		foreach(GameObject t in Timers)
		{
			t.GetComponent<Text>().text = record.text;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Submit()
	{
		//Push time to website
	}

	public void Close()
	{
		Popup.SetActive(false);
	}
}
