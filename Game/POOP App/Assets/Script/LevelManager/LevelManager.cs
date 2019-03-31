using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public int lifePoints = 1;

    public int current_life;

    private bool isDead = false;

    private int score = 0;

    public float time = 0;

    private float startTime = 0;

    public Transform player;

    public DeathMenu DM;

    private void Update()
    {
        float time = Time.time - startTime;

        //Run out of life -> Dies
        if(current_life <= 0)
        {
            isDead = true;
        }

        //Show Death Screen
        if(isDead)
        {
            DM.ToggleEndMenu(score,time);
        }
    }

    void Reset()
    {
        current_life = lifePoints;
        score = 0;
        time = 0;
        Start();
    }
    
    void Start()
    {
        startTime = Time.time;
        current_life = lifePoints;
    }
}