using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowTime : MonoBehaviour
{
    public LevelManager LM;

    public Text timerText;

    void Update()
    {
        string minutes = ((int)LM.time / 60).ToString();
        string seconds = (LM.time % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }   
}