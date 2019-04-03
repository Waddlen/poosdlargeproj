using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {

	private bool Active = false;

	private int TimeLimit = 10;

	public GameObject JS;

	public GameObject Cam;

	public GameObject player;

	public GameObject shadow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Activate()
	{
		Active = true;
		//Starts where player was
		shadow.transform.position = player.transform.position;
		GiveControl(shadow);
	}

	void GiveControl(Gameobject curPlayer)
	{

	}
}
