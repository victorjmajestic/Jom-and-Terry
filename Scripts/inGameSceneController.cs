using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


/* This script controls all elements/scene changes on the map.
 * Also contains variable references to be used throughout the game.
 */

public class inGameSceneController : MonoBehaviour
{

    public void Start()
    {
    }

    public void startGame()
    {
        Data.inGame = true;
    }

    public void quitGame()
    {
        Data.inGame = false;
    }

    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "SampleScene")
        {
            Data.lastCatPosition = GameObject.Find("cat").transform.position;
            Data.timerText = GameObject.Find("SceneController").GetComponent<Timer>().timeText.text;
            Data.lastHumanPosition = GameObject.Find("Human").transform.position;
            Data.currentQueue = GameObject.Find("Human").GetComponent<Human>().cleanQueue;
            Data.lastMousePosition = GameObject.Find("Mouse").transform.position;
        }
    }

}
