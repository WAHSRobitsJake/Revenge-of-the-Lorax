using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newGameChecker : MonoBehaviour
{
    public runeHandler rH;
    public GUISkin myGUISkin;
    
    void Start()
    {
        rH.isNewGame = true;
    }

    public void OnGUI()
    {
        GUI.skin = myGUISkin;
        GUI.Label(new Rect(10 , 150  , 200f, 200f), "The lonely lumberjack fills his time cutting down trees but after some time, ");
        GUI.Label(new Rect(10, 300 , 200f, 200f), "the Lorax appeared, and the Lorax was angry. ");
        GUI.Label(new Rect(10, 430, 200f, 200f), "The lumberjack only had thought once he made eye contact with the Lorax. Run.");
        GUI.Label(new Rect(390, Screen.height / 2, 200f, 200f), "Use AD to move, spacebar to jump, and left click to throw your axe");
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 80f, 80f), "Play!"))
        {
            SceneManager.LoadScene("runeScene");
        }
    }
}
