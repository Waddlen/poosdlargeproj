using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Game States
public enum GameState 
{
	DEFAULT,	// Fall-back state, should never happen
	INTRO,		// Game intro
	MAIN_MENU,	// Main menu
	OPTIONS,	// Options from the main menu
	LEVEL_SELECT,	// Select level
	LEVEL,		// Solving level
	GAME_OVER	// When you lose
};


public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public  GameState gameState { get; private set; }
	
	public delegate void OnSceneChangeHandler();
	public static event OnSceneChangeHandler OnSceneChange;

	// Prefab managers to be loaded, if any
	// public GameObject GUIManPrefab;

	void Awake () {
		// Singleton Pattern
		if (instance == null) {
			instance = this;
			instance.name = "Game Man";
			DontDestroyOnLoad(gameObject);
		}

		// Assign events
		UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;


		// Instantiate managers 
		// if (DialogueManager.instance == null) 	{ Instantiate(dialogueManPrefab, gameObject.transform); }

	}

	// Use this for initialization
	void Start () {
		
	}
	

	// Whenever scene is loaded, the event OnSceneChange is triggered
	void OnSceneLoaded(Scene scene, LoadSceneMode mode) {

		if (OnSceneChange != null) {
			OnSceneChange();
		}
	}
}
