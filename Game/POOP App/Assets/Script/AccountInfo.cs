using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountInfo : MonoBehaviour {
	string deviceID, nickName;

	public GameObject MenuButtons;

	public GameObject ScreenUI;

	public InputField user;

	// Use this for initialization
	void Start ()
	{
		int hasPlayed = PlayerPrefs.GetInt("hasPlayed");

		if(hasPlayed == 0)
		{
			//Create Account
			CreateAccount();
		}
	}
	
	// Update is called once per frame
	public void CreateAccount()
	{
			ScreenUI.SetActive(true);
			MenuButtons.SetActive(false);
	}

	public void Submit()
	{
		nickName = user.text;
		if(string.IsNullOrEmpty(nickName) == false)
		{
			deviceID = GenerateID();
			PlayerPrefs.SetString("deviceID", deviceID);
			PlayerPrefs.SetString("nickName", nickName);
			PlayerPrefs.SetInt("hasPlayed", 1);

			ScreenUI.SetActive(false);
			MenuButtons.SetActive(true);
		}	
	}

	public string GenerateID()
	{
		System.Random random = new System.Random();
		string id = Application.systemLanguage                            //Language
                 +"-"+string.Format("{0:X}", System.DateTime.Now.ToLongTimeString())                                            //Device    
                 +"-"+string.Format("{0:X}", random.Next(1000000000));
		return id;
	}
}
