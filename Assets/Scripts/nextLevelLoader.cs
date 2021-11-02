using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevelLoader : MonoBehaviour
{
    public listOfTerrain lOT;
    public void Start()
    {
      /*  if (SceneManager.GetActiveScene().name == "titleScene")
        {
            Invoke("loadNextLevel", 2.0f);
        }*/
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            if (lOT.level > 3)
            {
                SceneManager.LoadScene("winScene");
            } else
            {
                lOT.level++;
                SceneManager.LoadScene("runeScene");
            }
        }
    }
    void OnGUI()
    {
        if (SceneManager.GetActiveScene().name == "titleScene")
        {
            GUI.Label(new Rect(290, 100, 100, 100), "Welcome to The Lorax's Revenge");
            if (GUI.Button(new Rect(290, 200, 80, 40), "Start"))
            {

                Invoke("loadNextLevel", 2.0f);
            }
        }
    }
    public void loadNextLevel()
    {
        SceneManager.LoadScene("sampleScene");
    }
}
