using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour {

	
	public int curLevel = 1;

	public string email, id;

	public string L1Time, L2Time, L3Time;

	public PlayerData (Player player)
	{
		curLevel = player.curLevel;
		email = player.email;
		id = player.id;
		L1Time = player.L1Time;
		L1Time = player.L2Time;
		L1Time = player.L3Time;
	}
}
