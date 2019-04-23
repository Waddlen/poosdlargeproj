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
		//Popup.SetActive(true);
		


		GameObject[] Timers = GameObject.FindGameObjectsWithTag("Timer");
		foreach(GameObject t in Timers)
		{
			t.GetComponent<Text>().text = record.text;
		}
		// updateData(record.text, SceneManager.GetActiveScene().name);
		string id = PlayerPrefs.GetString("deviceID");
		string nick = PlayerPrefs.GetString("nickName");
		string level = System.Convert.ToString(SceneManager.GetActiveScene().buildIndex - 1);
		string yourTime = GetTime(record.text);
		Debug.Log(id);
		Debug.Log(nick);
		gameObject.GetComponent<sendJson>().sendUsernameToServer(id,nick);
		//gameObject.GetComponent<sendJson>().sendInfoToServer(id, record.text, "0", SceneManager.GetActiveScene().name);
		gameObject.GetComponent<sendJson>().sendInfoToServer(id, yourTime, "0", level);		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	string GetTime(string t)
	{
		string[] token = t.Split(':');
		float seconds = int.Parse(token[0]) * 60f;
		seconds += float.Parse(token[1]);
		return System.Convert.ToString(seconds);
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

			gameObject.GetComponent<sendJson>().sendInfoToServer(iName, record.text, "0", SceneManager.GetActiveScene().name);
			Debug.Log("iName = " + iName + ", record.text = " + record.text + "activeScene = " + SceneManager.GetActiveScene().name);

			Close();
		}
		else
		{
			Debug.Log("Didn't work");
		}
		
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
		//gameObject.GetComponent<PlayerInfo>().latestLvl = Lvl;
		//gameObject.GetComponent<PlayerInfo>().latestTime = time;
		//gameObject.GetComponent<PlayerInfo>().Saving();
	}
}

