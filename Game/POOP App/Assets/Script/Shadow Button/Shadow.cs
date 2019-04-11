using Cinemachine.Utility;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shadow : MonoBehaviour {

	private bool Active = false;

	private int TimeLimit = 10;

	public Joystick JS;

	public GameObject pCam;

	public GameObject sCam;

	public Transform player;

	public Transform shadow;

	public GameObject shadowSprite;

	public GameObject Swap;

	public Sprite SwapToWhite;

	public Sprite SwapToShadow;

	public GameObject LM;

	private LevelManager LMscript;

	//These are for the shaodw decay mechanic. Recommended sDR is 0.002f
	public GameObject Duration;

	private float meter = 0;

	private float meterMax = 1f;

	public float standardDR = 0.002f;

	public float replenishRate = 0.005f;

	private float decayRate;

	private float startDecay;

	public int DecayBoost = 0;
	
	//Mode 0 = Player, Mode 1 = Shadow
	private int mode = 1;

	// Use this for initialization
	void Start ()
	{
		LMscript = LM.GetComponent<LevelManager>();	
		meter = meterMax;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Active && meter > 0f)
		{
			//meter = ( meterMax - ( ( Time.time - startDecay ) * decayRate ) ) / meterMax;
			meter -= decayRate;
			Duration.GetComponent<Image>().fillAmount = meter;
		}

		if(!Active && meter < meterMax)
		{
			meter += replenishRate;
			Duration.GetComponent<Image>().fillAmount = meter;
		}

		if(meter <= 0f)
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
					Swap.GetComponent<Image>().sprite = SwapToWhite;
					break;
				case 1:
					mode = 0;
					GiveControl(player, pCam, sCam);
					Swap.GetComponent<Image>().sprite = SwapToShadow;
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
		mode = 1;
		Active = true;
		//Starts where player was
		shadow.transform.position = player.transform.position;
		shadowSprite.SetActive(true);
		GiveControl(shadow, sCam, pCam);

		Swap.SetActive(true);
		Decay();
	}

	public void Deactivate()
	{
		mode = 0;
		Active = false;
		GiveControl(player, pCam, sCam);
		shadowSprite.SetActive(false);

		Swap.SetActive(false);
	}

	public void Decay()
	{
		/*
		if(meter <= 0f)
		{
			yield break;
		}
		*/
		startDecay = Time.time;

		decayRate = standardDR;

		if(DecayBoost > 0)
		{
			decayRate += DecayBoost;
		}
		/*
		meter -= decayRate;
		Duration.GetComponent<Image>().fillAmount = meter;
		yield return new WaitForSeconds(.2f);
		*/
	}

	void GiveControl(Transform curPlayer, GameObject activeCam, GameObject nonCam)
	{
		JS.GetComponent<Joystick>().player = curPlayer;
		activeCam.SetActive(true);
		nonCam.SetActive(false);
	}
}