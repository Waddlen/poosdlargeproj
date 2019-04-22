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

	public void updateTime(string time, string Lvl)
	{
		string myTime = "";
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
		if(!myTime.Equals("0"))
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
		string[] token = str.Split(':');
		float val = (float.Parse(token[0]) * 60) + float.Parse(token[1]);
		return val;
	}
}
