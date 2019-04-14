using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelQuit : MonoBehaviour {


	
	// Update is called once per frame
	public void Quit ()
	{
		SceneManager.LoadScene("Main Menu");	
	}

		// Use this for initialization
	void Start ()
	{
		
	}
}
