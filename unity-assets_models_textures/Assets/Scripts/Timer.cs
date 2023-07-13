using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    public bool startTimer = false;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (startTimer) // Add this line
        {
            float t = Time.time - startTime;

            string minutes = ((int) t / 60).ToString();
            string seconds = ((int) t % 60).ToString("D2");
            string milliseconds = ((int) (t * 100 % 100)).ToString("D2");

            timerText.text = minutes + ":" + seconds + "." + milliseconds;
        }
    }
}
