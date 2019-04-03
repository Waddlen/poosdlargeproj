using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuScript : MonoBehaviour {

	// Use this for initialization
	private GUISkin skin;

	void Start()
	{
		skin = Resources.Load("GUISkin") as GUISkin;
	}
	void OnGUI()
	{
		const int buttonWidth = 185;
		const int buttonHeight = 135;
		GUI.skin = skin;

		if(
			GUI.Button(

			new Rect(
			(27 * Screen.width /100) - (buttonWidth / 2),
			(33 * Screen.height / 100) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
				),
				"Level 1"
				)
			  )

		{
			//On click, load level select.
			SceneManager.LoadScene("Level1");
		}
		
	}
}
