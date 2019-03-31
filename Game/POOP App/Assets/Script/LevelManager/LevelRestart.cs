using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestart : MonoBehaviour {
	
	//public string Level;
	public void Restart()
	{
		//SceneManager.LoadScene(Level);
		SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);
	}
	
	void Start()
	{
		Time.timeScale = 1;
	}
}