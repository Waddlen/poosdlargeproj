using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

	public int curLevel = 1;

	public string email = "yourname@gmail.com", id = "yourname";

	public string L1Time = null, L2Time = null, L3Time = null;

	public string latestTime = "";

	public string latestLvl = "";

	public void Saving()
	{
		//Debug.Log(latestLvl);
		LoadPlayer();
		updateTime(latestTime, latestLvl);
		SavePlayer();
	}
	
	public void SavePlayer()
	{
		SaveState.SavePlayer(this);
	}

	public void LoadPlayer()
	{
		PlayerData data = SaveState.LoadPlayer();
		if(data != null)
		{
			curLevel = data.curLevel;
			email = data.email;
			id = data.id;
			L1Time = data.L1Time;
			L1Time = data.L2Time;
			L1Time = data.L3Time;
		}
		else
		{
			Debug.Log("No Data Found");
		}
	}

	public void updateTime(string time, string Lvl)
	{
		Debug.Log("Updating...");

		string myTime = null;
		switch(Lvl)
		{
			case "Level1":
				myTime = L1Time;
				break;

			case "Level2":
				myTime = L1Time;
				break;

			case "Level3":
				myTime = L1Time;
				break;
		}

		float curTime = 0f;
		if(string.IsNullOrEmpty(myTime) == false)
		{
			curTime = ToFloat(myTime);
		}

		float newTime = ToFloat(time);

		if(newTime < curTime || curTime.Equals(0f))
		{
			switch(Lvl)
			{
				case "Level1":
					L1Time = time;
					break;

				case "Level2":
					L2Time = time;
					break;

				case "Level3":
					L3Time = time;
					break;
			}
		}
		updateLevel(Lvl);

	}

	public void updateLevel(string Lvl)
	{
		int myLvl = 1;
		switch(Lvl)
		{
			case "Level1":
				myLvl = 1;
				break;

			case "Level2":
				myLvl = 2;
				break;

			case "Level3":
				myLvl = 3;
				break;
		}
		if(myLvl > curLevel)
		{
			curLevel = myLvl;
		}
	}

	float ToFloat(string str)
	{
		//Debug.Log(str);
		string[] token = str.Split(':');
		/*
		foreach(string t in token)
		{
			Debug.Log(t);
		}
		*/
		float val = (float.Parse(token[0]) * 60) + float.Parse(token[1]);
		return val;
	}
}
