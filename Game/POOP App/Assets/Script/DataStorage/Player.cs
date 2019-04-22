using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int curLevel;

	public string email, id;

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
	}
}
