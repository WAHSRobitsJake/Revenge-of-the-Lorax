using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batSpawner : MonoBehaviour
{
    public GameObject bat;
    public Transform spawner;
    public float respawnCooldown = 25f;
    void Start()
    {
        //Instantiate(bat, spawner.position, Quaternion.identity);
    }

    void Update()
    {
        respawnCooldown -= 1 * Time.deltaTime;
        if (respawnCooldown <= 0)
        {
            Instantiate(bat, spawner.position, Quaternion.identity);
            respawnCooldown = 7.5f;
        }
    }
}
