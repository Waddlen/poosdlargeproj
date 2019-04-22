using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour {

	
	public int curLevel = 1;

	public string email, id;

	public PlayerData (Player player)
	{
		curLevel = player.curLevel;
		email = player.email;
		id = player.id;
	}
}
