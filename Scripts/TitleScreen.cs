using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* This script controls all elements of the title screen. */

public class TitleScreen : MonoBehaviour
{

    public void gameStart()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void optionSelect()
    {
        SceneManager.LoadScene("Options");
    }

    public void creditSelect()
    {
        SceneManager.LoadScene("Credits");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void Start()
    {
        Data.inGame = false;
    }

}
