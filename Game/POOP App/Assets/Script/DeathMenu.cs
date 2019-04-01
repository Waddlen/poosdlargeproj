using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public Text scoreText;

    public Text timeText;

    public GameObject LM;

    public GameObject UI;

	public GameObject Joystick;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ToggleEndMenu(int score,float time)
    {
        gameObject.SetActive(true);
        UI.SetActive(false);
		Joystick.SetActive(false);

        Time.timeScale = 0f;
        
        scoreText.text = score.ToString();
        timeText.text = time.ToString();
    }
}