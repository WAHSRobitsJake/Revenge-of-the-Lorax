using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batAI : MonoBehaviour
{
    public playerMovementHandler pMH;
    public float speed = 1.0f;
    public GameObject player;
    public float playerPosX, playerPosY;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        pMH = player.GetComponent<playerMovementHandler>();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
        if (player.transform.position.x > this.transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            pMH.loseScore();
            pMH.gameOverCheck();
            Destroy(this.gameObject);
        }
    }
}
