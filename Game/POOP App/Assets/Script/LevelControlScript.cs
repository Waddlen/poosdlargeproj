using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControlScript : MonoBehaviour {

	public static LevelControlScript instance = null;
	GameObject levelSign, youWinText;
	int sceneIndex, levelPassed;

	// Use this for initialization
	void Start () {

		if(instance == null)
			instance = this;
		else if(instance != this)
			Destroy(gameObject);

		levelSign = GameObject.Find("LevelNumber");
		//gameOverText = GameObject.Find("GameOverText");
		youWinText = GameObject.Find("YouWinText");
		//gameOverText.gameObject.SetActive(false);
		youWinText.gameObject.SetActive(false);

		sceneIndex = SceneManager.GetActiveScene().buildIndex;
		levelPassed = PlayerPrefs.GetInt("LevelPassed");
	}
	
	public void youWin()
	{
		if(sceneIndex == 3)
			Invoke("loadLevelSelect", 1f);
		else {
			if(levelPassed < sceneIndex)
				PlayerPrefs.SetInt("LevelPassed", sceneIndex);
			levelSign.gameObject.SetActive(false);
		}
	}
/* 
	public void youLose()
	{
		levelSign.gameObject.SetActive(false);
		gameOverText.gameObject.SetActive(true);
		Invoke("loadMainMenu", 1f);
	}
	*/
	void loadNextLevel()
	{
		SceneManager.LoadScene(sceneIndex +1);
	}

	void loadLevelSelect()
	{
		SceneManager.LoadScene("LevelSelect");
	}
}
