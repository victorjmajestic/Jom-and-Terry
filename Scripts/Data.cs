using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    public static bool inGame = false; //is the player in game or not?
    public static Vector3 lastCatPosition; //current position of the cat
    public static Vector3 lastHumanPosition; //current position of the human
    public static Vector3 lastMousePosition; //current position of the mouse
    public static Queue<GameObject> currentQueue; //current queue for the human
    public static string timerText;        //current timer text
    public static float timeRemaining = 180; // current time remaining
    public static bool fromPause;          //is the player returning from the pause menu?
    public static float universalVolume = 1; //the master volume
    public static Vector3 lastMessSpot;   //spot where the mess is
    public static bool messPresent;       //if the mess is present or not
    public static int score = 0;
    public static int multiplier;
}
