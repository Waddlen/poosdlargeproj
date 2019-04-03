using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	private GUISkin skin;

	void Start()
	{
		skin = Resources.Load("GUISkin") as GUISkin;
	}
	void OnGUI()
	{
		const int buttonWidth = 250;
		const int buttonHeight = 100;
		GUI.skin = skin;

		if(
			GUI.Button(

			new Rect(
			Screen.width /2 -(buttonWidth / 2),
			(53 * Screen.height / 100) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
				),
				"Level Select"
				)
			  )

		{
			//On click, load level select.
			SceneManager.LoadScene("LevelSelect");
		}

		if(
			GUI.Button(

			new Rect(
			Screen.width /2 -(buttonWidth / 2),
			(71 * Screen.height / 100) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
				),
				"Options"
				)
			  )
		
				{
			//On click, load level select.
			SceneManager.LoadScene("Options");
		}


		if(
			GUI.Button(

			new Rect(
			Screen.width /2 -(buttonWidth / 2),
			(88 * Screen.height / 100) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
				),
				"Leaderboard"
				)
			  )
		
				{
			//On click, load level select.
			SceneManager.LoadScene("Leaderboard");
		}

	}
}
