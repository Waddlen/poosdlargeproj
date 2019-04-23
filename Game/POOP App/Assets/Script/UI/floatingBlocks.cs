using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingBlocks : MonoBehaviour {

	public float floatSpeed;
	public float floatRadius;
	float startTime;
	Vector2 startPosition;

	// Use this for initialization
	void Start () {

		startPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
		startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		
		// Set transform position based on a sine function and time
		gameObject.transform.position = new Vector2(startPosition.x, 
				startPosition.y + floatRadius * Mathf.Sin(floatSpeed * (Time.time - startTime)));

	}
}
