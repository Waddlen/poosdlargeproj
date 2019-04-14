using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

	private Transform Player;

    private Transform Shadow;

    private Transform Target;

	public GameObject Bullet;

    public GameObject LM;

    public bool DetectShadow = false;

    public bool DetectPlayer = true;

    private bool DetectBoth = false;

	public int Range = 12;

    public float fireRate = 1f;

	public float speed = 5f;

	private float nextFire;

	private Vector3 dir;

	// Use this for initialization
	void Start ()
	{
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Shadow = GameObject.FindGameObjectWithTag("Shadow").GetComponent<Transform>();

		nextFire = Time.time;

		if(DetectPlayer && DetectShadow)
        {
            DetectBoth = true;
        }	
	}
	
	// Update is called once per frame
	void Update ()
	{
		FindTarget();
	}

	void FindTarget()
	{
		if(DetectBoth)
        {
            FireAtBoth();
        }
        else
        {
            if(DetectShadow)
            {
                if(Vector2.Distance(transform.position, Shadow.position) < Range)
                {
                    Target = Shadow;
                    FireAtTarget();
                }
            }

            if(DetectPlayer)
            {
                
                if(Vector2.Distance(transform.position, Player.position) < Range)
                {
                    Target = Player;
                    FireAtTarget();
                }
            }
        }
	}

	void FireAtBoth()
	{
		if(Vector2.Distance(transform.position, Player.position) < Range)
        {
            Target = Player;
            FireAtTarget();
        }
        else
        {
            if(Vector2.Distance(transform.position, Shadow.position) < Range)
            {
                Target = Shadow;
                FireAtTarget();
            }
        }
	}

	void FireAtTarget()
	{
		//Face Target
		Vector3 TargetAngle = Target.position - transform.position;
		float angle = (Mathf.Atan2(TargetAngle.y, TargetAngle.x) * Mathf.Rad2Deg) - 90;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 3f);

		if(Time.time > nextFire)
		{
			GameObject newBullet;
			
			newBullet = Instantiate(Bullet, transform.position + transform.forward * 500, Quaternion.identity);
			Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
			rb.velocity = (new Vector2(TargetAngle.x, TargetAngle.y)) * speed;
			
			/*
			newBullet = Instantiate(Bullet,transform.position,Quaternion.identity);
			newBullet.GetComponent<EnemyBullet>().Spawn(Target,speed);
			*/

			nextFire = Time.time + fireRate;
		}
	}
}
