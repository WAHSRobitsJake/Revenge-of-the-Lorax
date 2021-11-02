using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runeScene : MonoBehaviour
{
    // Start is called before the first frame update
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
        
        //GUI.Label(new Rect(250, 100, 100, 100), "Choose as many runes as you want for the next level");
      


    }
}

