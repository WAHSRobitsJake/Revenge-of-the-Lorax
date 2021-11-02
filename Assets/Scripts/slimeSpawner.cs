using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeSpawner : MonoBehaviour
{
    public GameObject slime;
    public Transform spawner;
    public float respawnCooldown = 19f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        respawnCooldown -= 1 * Time.deltaTime;
        if (respawnCooldown <= 0)
        {
            Instantiate(slime, spawner.position, Quaternion.identity);
            respawnCooldown = 9.5f;
        }
    }
}
