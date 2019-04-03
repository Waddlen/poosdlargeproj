using Cinemachine.Utility;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {

	private bool Active = false;

	private int TimeLimit = 10;

	public Joystick JS;

	public GameObject pCam;

	public GameObject sCam;

	public Transform player;

	public Transform shadow;

	public GameObject shadowSprite;

	public GameObject LM;

	private LevelManager LMscript;
	
	//Mode 0 = Player, Mode 1 = Shadow
	private int mode = 1;

	// Use this for initialization
	void Start ()
	{
		LMscript = LM.GetComponent<LevelManager>();	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(LMscript.current_life <= 0)
		{
			Deactivate();
		}
	}

	//Second Button to Switch target player while shadow mode is active
	public void ToggleTarget()
	{
		if(Active)
		{
			switch(mode)
			{
				case 0:
					mode = 1;
					GiveControl(shadow, sCam, pCam);
					break;
				case 1:
					mode = 0;
					GiveControl(player, pCam, sCam);
					break;
			}

		}
	}

	//Activate and Deactivate Shadow
	public void ToggleButton()
	{
		if(!Active)
		{
			Activate();
		}
		else
		{
			Deactivate();
		}

	}

	void Activate()
	{
		Active = true;
		//Starts where player was
		shadow.transform.position = player.transform.position;
		shadowSprite.SetActive(true);
		GiveControl(shadow, sCam, pCam);
	}

	void Deactivate()
	{
		Active = false;
		GiveControl(player, pCam, sCam);
		shadowSprite.SetActive(false);
	}

	void GiveControl(Transform curPlayer, GameObject activeCam, GameObject nonCam)
	{
		JS.GetComponent<Joystick>().player = curPlayer;
		activeCam.SetActive(true);
		nonCam.SetActive(false);
	}
}