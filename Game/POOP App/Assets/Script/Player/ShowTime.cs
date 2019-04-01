using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowTime : MonoBehaviour
{

    public Text timerText;

    private float startTime;

    public string record;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        record = minutes + ":" + seconds;
        timerText.text = record;
    }   
}