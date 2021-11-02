using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winScene : MonoBehaviour
{
    public global variableHandler;
    public GUISkin myGUISkin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnGUI()
    {
        GUI.skin = myGUISkin;
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 - 200, 200f, 200f), "Congratulations! You survived the wrath of the Lorax.");
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 - 50, 200f, 200f), "Here's your score: " + variableHandler.score);
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2+ 100, 200f, 200f), "Here's your high score: " + variableHandler.highScore);
        if(GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 200,100f, 100f), "Play again?"))
        {
            SceneManager.LoadScene("titleScene");
        }
               
    }
}
