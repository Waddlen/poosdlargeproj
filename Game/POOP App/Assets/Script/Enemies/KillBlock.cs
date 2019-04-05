using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KillBlock : MonoBehaviour {

	public int MoveSpaces = 0;

	public float delay = 0f;

	private float timer;

	public float speed = 1f;

	public bool UpDown = false;

	public bool LeftRight = false;

    private bool isMoving = false;

    private int direction = 1;

	Rigidbody2D myBody;
	Vector3 Dest;

	private bool atDest = true;

	// Use this for initialization
	void Start ()
	{
		if((UpDown || LeftRight) && speed > 0)
		{
			myBody = GetComponent<Rigidbody2D>();
            isMoving = false;
            timer = delay;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
        if(!isMoving)
        {
            timer -= Time.deltaTime;

            myBody.velocity = Vector2.zero;

            if(timer < 0)
            {
                isMoving = true;
				chooseDirection();
            }
        }

		if(!atDest)
		{
			checkDest();
		}
	}

	private void chooseDirection()
	{
		timer = delay;

		if(direction < 4)
		{
			direction += 1;
		}
		else
		{
			direction = 1;
		}

		Move();
	}

	private void Move()
    {
        if(direction == 1)
        {
            if(UpDown)
            {
                myBody.velocity = new Vector2(0, speed);

				Dest = transform.position;
				Dest.y += MoveSpaces;
				atDest = false;
            }
            else
            {
                direction = 2;
            }
        }

        if(direction == 2)
        {
            if(LeftRight)
            {
                myBody.velocity = new Vector2(speed, 0);

				Dest = transform.position;
				Dest.x += MoveSpaces;
				atDest = false;
            }
            else
            {
                direction = 3;
            }
        }

        if(direction == 3)
        {
            if(UpDown)
            {
                myBody.velocity = new Vector2(0, -(speed));

				Dest = transform.position;
				Dest.y -= MoveSpaces;
				atDest = false;
            }
            else
            {
                direction = 4;
            }
        }

        if(direction == 4)
        {
            if(LeftRight)
            {
                myBody.velocity = new Vector2(-(speed),0);

				Dest = transform.position;
				Dest.x -= MoveSpaces;
				atDest = false;
            }
            else
            {
                direction = 1;
                Move();
            }
        }
    }

	private void checkDest()
	{
		if(direction == 1)
		{
			if(transform.position.y >= Dest.y)
			{
				isMoving = false;
				atDest = true;
			}
		}

		if(direction == 2)
		{
			if(transform.position.x >= Dest.x)
			{
				isMoving = false;
				atDest = true;
			}
		}

		if(direction == 3)
		{
			if(transform.position.y <= Dest.y)
			{
				isMoving = false;
				atDest = true;
			}
		}

		if(direction == 4)
		{
			if(transform.position.x <= Dest.x)
			{
				isMoving = false;
				atDest = true;
			}
		}
	}
}