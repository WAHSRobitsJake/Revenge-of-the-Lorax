using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axe : MonoBehaviour
{
    public playerMovementHandler pMH;
    public GameObject player;
    public Vector2 axeDestination;
    public float axeSpeed = 3.0f;
    public float returnSpeed = 3.0f;
    public float returnCooldown = 2.0f;
    public float timeAlive = 0.0f;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        pMH = player.GetComponent<playerMovementHandler>();
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }
    public void Update()
    {
            returnCooldown -= 1 * Time.deltaTime;
            if (returnCooldown <= 0)
            {
            timeAlive += 1 * Time.deltaTime;
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, axeSpeed*Time.deltaTime+(timeAlive/12));
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), false);
        }
            if (returnCooldown > 0)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, axeDestination, (axeSpeed * Time.deltaTime));
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bat"))
        {
            pMH.score += 5;
            pMH.batKills++;
            Destroy(other.gameObject);
            returnCooldown = 0;
        }
        if (other.gameObject.CompareTag("slime"))
        {
            returnCooldown = 0;
        }
        if (other.gameObject.CompareTag("tree"))
        {
            returnCooldown = 0;
            pMH.score++;
        }
    }
}
