using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class WinScreen : MonoBehaviour {

	public Text record;

	public InputField Input;

	public GameObject Popup;

	private string iName = null;

	string url = "http://3.89.35.102/";

	void Start ()
	{
		//GameObject.FindGameObjectWithTag("Player").GetComponent<ShowTime>().record = record;
		Popup.SetActive(true);


		GameObject[] Timers = GameObject.FindGameObjectsWithTag("Timer");
		foreach(GameObject t in Timers)
		{
			t.GetComponent<Text>().text = record.text;
		}
		// updateData(record.text, SceneManager.GetActiveScene().name);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	public void Submit()
	{
		iName = Input.text;
		
		if(string.IsNullOrEmpty(iName) == false)
		{
			/*
			pkg data = new pkg
			{
				name = Input.text,
				winTime = record.text
			};

			string json = JsonUtility.ToJson(data);

			File.WriteAllText(Application.dataPath + "/score.txt", json);

			WWWForm form = new WWWForm();
			form.AddField("x",json);
			WWW send = new WWW (url,form);
			*/

			// Convert time to double
			string time = timeToDouble(record.text);

			// Convert level name to integer but slicing off the "Level" string
			string levelInt = SceneManager.GetActiveScene().name.Substring(5);

			Debug.Log("time = " + time + ", levelInt = " + levelInt);
			gameObject.GetComponent<sendJson>().sendInfoToServer(iName, time, "0", levelInt);

			Close();
		}
		else
		{
			Debug.Log("Didn't work");
		}
		
	}

	// Converts time format of e.g. 0:23.29 to a double
	string timeToDouble(string timeText) {

		char[] delimiterChars = { ':', '.' };
		string[] splitStrings = timeText.Split(delimiterChars);

		double time = 0;
		double x;

		Double.TryParse(splitStrings[0], out x);
		time += x * 60;	// Minutes
		Double.TryParse(splitStrings[1], out x);
		time += x;		// Seconds
		Double.TryParse(splitStrings[2], out x);
		time += x / 100; // Hundredths of seconds

		return time.ToString("F4");
	}

	private class pkg
	{
		public string name;
		public string winTime;
	}

	public void Close()
	{
		Popup.SetActive(false);
	}

	public void updateData(string time, string Lvl)
	{
		gameObject.GetComponent<PlayerInfo>().latestLvl = Lvl;
		gameObject.GetComponent<PlayerInfo>().latestTime = time;
		gameObject.GetComponent<PlayerInfo>().Saving();
	}
}
