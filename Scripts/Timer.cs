using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 180;
    public bool timerIsRunning = false;
    public Text timeText;
    [SerializeField] public GameObject key;

    private void Start()
    {

        timerIsRunning = true;
        timeRemaining = Data.timeRemaining;
        timeText.text = Data.timerText;
    }

    public void Restart()
    {
        timerIsRunning = true;
        Data.timeRemaining = 180;
        timeRemaining = Data.timeRemaining;
        timeText.text = Data.timerText;
    }

    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (timerIsRunning)
        {
            if (currentScene != "SampleScene")
            {
                timerIsRunning = false;
            }
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                key.SetActive(true);
                key.transform.position = Data.lastHumanPosition;
            }
        }
        if (timeRemaining > 120)
        {
            Data.multiplier = 1;
        }
        else if (timeRemaining > 60)
        {
            Data.multiplier = 2;
        }
        else if (timeRemaining > 0)
        {
            Data.multiplier = 4;
        }
        else
        {
            Data.multiplier = 0;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
    }
}
