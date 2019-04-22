using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int curLevel;

	public string email, id;

	public string L1Time, L2Time, L3Time;

	public void SavePlayer()
	{
		SaveState.SavePlayer(this);
	}

	public void LoadPlayer()
	{
		PlayerData data = SaveState.LoadPlayer();

		curLevel = data.curLevel;
		email = data.email;
		id = data.id;
		L1Time = data.L1Time;
		L1Time = data.L2Time;
		L1Time = data.L3Time;
	}
}
