using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeScript : MonoBehaviour
{
    public playerMovementHandler pMH;
    public GameObject player;
    public Vector2 targetDestination = Vector2.zero;
    public int health = 5;
    public float distanceToPlayerX;
    public float differenceToPlayerY;

    public float forceMultiplier = 45;
    public float forceX;
    public float forceY;
    public float jumpCooldown = 5.0f;
    public float directionX;
    public bool isJumping = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        pMH = player.GetComponent<playerMovementHandler>();
    }
    void Update()
    {
        jumpCooldown -= 1 * Time.deltaTime;
        if (jumpCooldown <= 0)
        {
            findDestination();
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY));
            jumpCooldown = 5.0f;
        }
        if (health <= 0)
        {
            pMH.slimeKills++;
            Destroy(this.gameObject);
        }
    }
    public void findDestination()
    {
        targetDestination.x = player.transform.position.x;
        targetDestination.y = player.transform.position.y;
        distanceToPlayerX = Mathf.Abs(transform.position.x - player.transform.position.x);
        differenceToPlayerY = Mathf.Abs(transform.position.y - player.transform.position.y);
        if (player.transform.position.x < transform.position.x)
        {
            directionX = -1;
        }else
        {
            directionX = 1;
        }

        if (distanceToPlayerX <= 6.0f) {
            forceX = directionX*400.0f;
        } else {
            forceX = directionX*distanceToPlayerX / 10 * forceMultiplier;
        }
        if (differenceToPlayerY <= 1.5f) {
            forceY = 150.0f;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("axe"))
        {
            health--;
            GetComponent<SpriteRenderer>().color = new Color(1f, health / 5f, health / 5f);
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            pMH.loseScore();
            pMH.gameOverCheck();
        }
    }
}
