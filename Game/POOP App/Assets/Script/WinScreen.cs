using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class WinScreen : MonoBehaviour {

	public Text record;

	public InputField Input;

	public GameObject Popup;

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
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Submit()
	{
		if(string.IsNullOrEmpty(Input.text) == false)
		{
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
			Close();
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
}
