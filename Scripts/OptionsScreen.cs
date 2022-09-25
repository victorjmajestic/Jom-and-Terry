using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

/* This script controls everything on the options/how to play screen. */

public class OptionsScreen : MonoBehaviour
{

    public void returntoGame()
    {
        Debug.Log("You pressed");
        SceneManager.LoadScene("TitleScreen");
    }

    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void howToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
