using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class deathBox : MonoBehaviour
{
    void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("endScene");
        }
    }
}
