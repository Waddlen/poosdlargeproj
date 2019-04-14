using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	// Use this for initialization
	//public Transform Target;

	public float speed;

	private Vector2 dir;

	private bool alive;

	private float startTime;

	void Start ()
	{
		//Debug.Log("Boom");
		alive = true;
		startTime = Time.time;
	}

	public void Spawn(Transform Target, float s)
	{
		dir = new Vector2(Target.position.x, Target.position.y);
		speed = s;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
		if(5 <= Time.time - startTime)
		{
			alive = false;
		}

		if(!alive)
		{
			Destroy(gameObject);
		}
	}
}
