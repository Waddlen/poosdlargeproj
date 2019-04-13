using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    private Transform Player;

    private Transform Shadow;

    private Transform Target;

    public GameObject LM;

    public bool DetectShadow = false;

    public bool DetectPlayer = true;

    private bool DetectBoth = false;

	private bool Chase = false;

    private bool atSpawn = true;

    public int Range = 7;

    public float speed = 0.3f;

    private Vector3 startPoint;

    private Vector3 dir;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Shadow = GameObject.FindGameObjectWithTag("Shadow").GetComponent<Transform>();
        startPoint = Vector3.zero;

        if(DetectPlayer && DetectShadow)
        {
            DetectBoth = true;
        }
    }

    void Update ()
	{
        ChaseCheck();

        if(LM.GetComponent<LevelManager>().current_life <= 0)
        {
           Reset();
        }
        if(transform.position.Equals(startPoint))
        {
            atSpawn = true;
        }

	}

    void ChaseCheck()
    {
        if(DetectBoth)
        {
            ChasePriority();
        }
        else
        {
            if(DetectShadow)
            {
                if(Vector2.Distance(transform.position, Shadow.position) < Range)
                {
                    Target = Shadow;
                    ChaseTarget();
                }
                else
                {
                    ReturnToStart();
                }
            }
            
            if(DetectPlayer)
            {
                
                if(Vector2.Distance(transform.position, Player.position) < Range)
                {
                    Target = Player;
                    ChaseTarget();
                }
                else
                {
                ReturnToStart();
                }
            }
        }
        
    }

    void OnCollisionEnter2d(Collider2D col)
    {
        if(col.gameObject.tag.Equals("Player") || col.gameObject.tag.Equals("Shadow"))
        {
            Reset();
        }
    }

    void ChaseTarget()
    {
        Chase = true;
        atSpawn = false;
        dir = Target.position - transform.position;
        transform.Translate(dir * 0.02f * speed);
    }

    void ChasePriority()
    {
        if(Vector2.Distance(transform.position, Player.position) < Range)
        {
            Target = Player;
            ChaseTarget();
        }
        else
        {
            if(Vector2.Distance(transform.position, Shadow.position) < Range)
            {
                Target = Shadow;
                ChaseTarget();
            }
            else
            {
                ReturnToStart();
            }
        }
    }

    void ReturnToStart()
    {
        Chase = false;
        dir = startPoint - transform.position;
        transform.Translate(dir * 0.05f * speed);
    }

    void Reset()
    {
        Chase = false;
        transform.position = startPoint;
    }
}