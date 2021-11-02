using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endSceneCode : MonoBehaviour
{
    public global variableHandler;
    public AudioClip gameOverClip;
    public AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(gameOverClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        GUI.Label(new Rect(250, 40, 120, 40), "Aw man, you lost!");
        GUI.Label(new Rect(50, 70, 120, 40), "Here's your high score " + variableHandler.highScore);
        if (GUI.Button(new Rect(250, 100, 80, 40), "Replay"))
        {
            SceneManager.LoadScene("titleScene");
          

        }
    }
}
