using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    public void returnToOptions()
    {
        if (Data.inGame)
        {
            SceneManager.LoadScene("Options2");
        }
        else
        {
            SceneManager.LoadScene("Options");
        }
    }

    public void beginGame()
    {
        SceneManager.LoadScene("SampleScene");
        GameObject.Find("Controller").GetComponent<inGameSceneController>().startGame();
    }

}