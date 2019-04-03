using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenuControlScript : MonoBehaviour {
	public Button level2, level3;
	int levelPassed;



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
	}
	
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


	// Update is called once per frame
//	void Update () {
		
//	}
}
