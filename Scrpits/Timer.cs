using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text GameOver;
    private float currentTime = 0f;
    private float startTime = 30f;

    void Start()
    {
        currentTime = startTime;
    }

  
    void Update()
    {
            currentTime -= 1 * Time.deltaTime;
            timerText.text = "Timer: " + currentTime.ToString("f0");
        if (currentTime <= 0)
        {
            currentTime = 0;
            timerText.text = currentTime.ToString("f0");
        }
        if(GameOver.text == "Game Over Game Created by Curtis Marcoux")
        {
            currentTime = 0;
            timerText.text = currentTime.ToString("f0");
        }
    }
}
