using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb;
	private Vector2 moveVelocity;

	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//Arrow Key Inputs (Ex. x,y = 1,-1)
		Vector2 moveInput = new Vector2( Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") );
		moveVelocity = moveInput.normalized * speed;
	}

	void FixedUpdate() {

		rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
	}
}
