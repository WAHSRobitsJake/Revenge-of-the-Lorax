using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITemp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(500, 125, 80, 40), "Rune Choose");
        GUI.Label(new Rect(50, 125, 80, 40), "Rune Chosen");
    }
}
