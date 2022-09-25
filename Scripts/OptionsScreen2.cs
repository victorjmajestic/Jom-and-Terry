using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

/* This script controls everything on the options/how to play screen. */

public class OptionsScreen2 : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseMenuElements;
    public GameObject instructionElements;

    public void Start()
    {
        //GameObject.Find("Controller").GetComponent<Timer>().timeText.text = Data.timerText;
        //timer to match what timer stopped at
    }

    public void restart()
    {
        //GameObject.Find("SceneController").GetComponent<Timer>().Restart();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("TitleScreen");

    }

    public void howToPlay()
    {
        pauseMenuElements.SetActive(false);
        instructionElements.SetActive(true);
    }

    public void returntoPause()
    {
        instructionElements.SetActive(false);
        pauseMenuElements.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseMenuElements.SetActive(true);
        instructionElements.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
