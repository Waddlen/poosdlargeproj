using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenuControlScript : MonoBehaviour {
	public Button level2, level3;
	int levelPassed;
    //private GUISkin skin;



    // Use this for initialization
    void Start () {
		levelPassed = PlayerPrefs.GetInt("LevelPassed");
		level2.interactable = false;
		level3.interactable = false;

		switch(levelPassed){
			case 1:
				level2.interactable = true;
				break;
			case 2:
				level2.interactable = true;
				level3.interactable = true;
				break;
		}
        ///skin = Resources.Load("GUISkin") as GUISkin;
    }


/* 
    void OnGUI()
    {
        const int buttonWidth = 150;
        const int buttonHeight = 50;
        GUI.skin = skin;

        if (
            GUI.Button(

            new Rect(
            Screen.width / 6 - (buttonWidth / 2),
            (20 * Screen.height / 100) - (buttonHeight / 2),
            buttonWidth,
            buttonHeight
                ),
                "Main Menu"
                )
              )

        {
            //On click, load level select.
            SceneManager.LoadScene("Main Menu");
        }
    }
*/

    public void levelToLoad(int level)
	{
		SceneManager.LoadScene("level" + level);
	}

	public void resetPlayerPres()
	{
		level2.interactable = false;
		level3.interactable = false;
		PlayerPrefs.DeleteAll();
	}

/* 
    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                // Insert Code Here (I.E. Load Scene, Etc)
                // OR Application.Quit();

                SceneManager.LoadScene("Main Menu");

                return;
            }
        }
    }
    */
}
