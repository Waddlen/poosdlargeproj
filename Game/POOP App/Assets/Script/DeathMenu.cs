using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public Text scoreText;

    public Text timeText;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ToggleEndMenu(int score, double time)
    {
        gameObject.SetActive(true);
        scoreText.text = score.ToString();
        timeText.text = time.ToString();
    }
}