using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public Text scoreText;

    public Text timeText;

    public GameObject LM;

    private LevelManager Level_Manager;

    public GameObject player;

    private LevelManager Show_Time;

    void Start()
    {
        Level_Manager = LM.GetComponent<LevelManager>();
        //Show_Time = player.GetComponent<ShowTime>();
        gameObject.SetActive(false);
    }

    public void ToggleEndMenu(int score,float time)
    {
        gameObject.SetActive(true);
        scoreText.text = score.ToString();
        timeText.text = time.ToString();
    }
}