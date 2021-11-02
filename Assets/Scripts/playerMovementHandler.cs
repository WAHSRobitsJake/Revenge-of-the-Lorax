using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementHandler : MonoBehaviour
{
    public gameManager GM;
    public global variablehandler;

    public Animator aC;
    public Animation jump;
    private GameObject axeObject;
    public GameObject player;
    public GameObject leftAxe;
    public GameObject rightAxe;
    public Transform throwPositionRight;
    public Transform throwPositionTop;
    public Transform throwPositionLeft;
    public Transform actualThrowPos;
    public AudioSource audioSource;
    public SpriteRenderer mySprite;
    public runeHandler rH;
    public List<AudioClip> jumpClips;
    public List<AudioClip> swingClips;
    public List<AudioClip> hurtClips;
    public List<AudioClip> deathClips;
    public AudioClip gameOverClip;
    public int treesDestroyed;
    public bool boost = true;
    public bool isFlipped = false;
    public int boostCounter = 1;
    public int boostTimer = 0;
    public int score = 10;
    public int axeThrown = 0;
    public int maxAxes = 1;
    public int scoreMultiplier = 1;
    public int batKills = 0;
    public int slimeKills = 0;
    void Start()
    {
        variablehandler.gameReset();
        aC = GetComponent<Animator>();
        runeChecker();
        audioSource = GetComponent<AudioSource>();

        jump = GetComponent<Animation>();
    }
    void Update()
    {
        GM.runeAdder();
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            var vel = GetComponent<Rigidbody2D>().velocity;
            vel.x = 0;
            GetComponent<Rigidbody2D>().velocity = vel;
            aC.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            var vel = GetComponent<Rigidbody2D>().velocity;
            vel.x = getSpeed();
            flipSprite();
            GetComponent<Rigidbody2D>().velocity = vel;
            aC.SetBool("isWalking", true);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("F");
            var vel = GetComponent<Rigidbody2D>().velocity;
            vel.x = -1 * getSpeed();
            flipSprite();
            GetComponent<Rigidbody2D>().velocity = vel;
            aC.SetBool("isWalking", true);
        }
        boostTimer++;
        if (boostTimer >= 450)
        {
            boostCounter++;
            boostTimer = 0;
        }
        if (boostCounter >= 1)
        {
            boostCounter = 1;
            boost = true;
        }
        if (boostCounter <= 0)
        {
            boost = false;
        }
        if (boost == true && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            int rand = Random.Range(0, 4);
            audioSource.PlayOneShot(jumpClips[rand]);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 375.0f));
            boostCounter = 0;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && axeThrown < maxAxes)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.y >= this.transform.position.y + 0.5f)
            {
                actualThrowPos = throwPositionTop;
                axeObject = Instantiate(leftAxe, actualThrowPos.position, Quaternion.identity);
                axeObject.GetComponent<axe>().axeDestination = mousePos;
                axeThrown++;
            }
            else if (mousePos.x < this.transform.position.x)
            {
                actualThrowPos = throwPositionLeft;
                actualThrowPos = throwPositionTop;
                axeObject = Instantiate(leftAxe, actualThrowPos.position, Quaternion.identity);
                axeObject.GetComponent<axe>().axeDestination = mousePos;
                axeThrown++;
            }
            else if (mousePos.x >= this.transform.position.x)
            {
                actualThrowPos = throwPositionRight;
                actualThrowPos = throwPositionTop;
                axeObject = Instantiate(rightAxe, actualThrowPos.position, Quaternion.identity);
                axeObject.GetComponent<axe>().axeDestination = mousePos;
                axeThrown++;
            }
        }
        if (GetComponent<Rigidbody2D>().velocity.y > 0.02f)
        {
            aC.SetBool("isJumping", true);
        }else
        {
            aC.SetBool("isJumping", false);
        }
        variablehandler.score = score;
        variablehandler.batKills = batKills;
        variablehandler.slimeKills = slimeKills;
    }
    public float getSpeed()
    {
        float baseSpeed = 6.0f;
        foreach (GameObject gameObject in rH.activeRunes)
        {
            runeScript rS = gameObject.GetComponent<runeScript>();
            if (rS.name == "Minor Speed Rune")
            {
                baseSpeed = 8.0f;
            }
            else if (rS.name == "Major Speed Rune")
            {
                baseSpeed = 10.0f;
            }
            else
            {
                baseSpeed = 6.0f;
            }
        }
        return baseSpeed;
    }
    public void flipSprite()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            mySprite.flipX = false;
            isFlipped = false;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            mySprite.flipX = true;
            isFlipped = true;
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("tree") && Input.GetKeyDown(KeyCode.X))
        {
            int rand = Random.Range(0, 4);
            aC.SetTrigger("isSwinging");
            audioSource.PlayOneShot(swingClips[rand]);
            Debug.Log("Solid");
            score += 10 * scoreMultiplier;
            Destroy(other.gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("axe"))
        {
            Destroy(other.gameObject);
            axeThrown--;
        }
    }
    public void loseScore()
    {
        score -= 5;
        int rand = Random.Range(0, 5);
        audioSource.PlayOneShot(hurtClips[rand]);
    }
    public void gameOverCheck()
    {
        if (score < 0){
            int rand = Random.Range(0, 7);
            GM.gameOver();
        }
    }
    public void runeChecker()
    {
        foreach (GameObject gameObject in rH.activeRunes)
        {
            runeScript rS = gameObject.GetComponent<runeScript>();
            if (rS.name == "Double Axes Rune")
            {
                maxAxes = 2;
            }
            if (rS.name == "Double Points Rune")
            {
                scoreMultiplier = 2;
            }
            if (rS.name == "Minor Health Rune")
            {
                score += 10;
            }
            if (rS.name == "Major Health Rune")
            {
                score += 20;
            }
        }
    }
}
