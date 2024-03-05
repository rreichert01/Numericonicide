using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float timeRemaining = 60f; 
    private bool timerIsRunning = false;
    public Text timerText; 

    // void Start()
    // {
    //     StartTimer(); 
    // }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerUI();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                // Handle timer expiration here
            }
        }
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    void UpdateTimerUI()
    {
        // Convert time remaining to minutes and seconds
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Update the Text component with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
