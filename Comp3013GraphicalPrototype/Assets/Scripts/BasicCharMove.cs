using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharMove : MonoBehaviour
{
    [SerializeField] bool isfalling;
    [SerializeField] bool hasDoubleJumped;
    [SerializeField] bool canDoubleJump;
    private Vector3 tempPos;
    public GameObject character;
    public float movementModifier;
    public float jumpModifier;
    public int health = 4;
    public int score;
    public Rigidbody2D characterBody;
    public float fallThresh = 0.0f;
    private GameObject eventSystem;
    public bool isColoured = false;
    private SpriteRenderer sprites;
    [SerializeField] Sprite newSprite;
    private GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("HealthBar");
        eventSystem = GameObject.Find("EventSystem");
        sprites = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isColoured)
        {
            colourCheck();
        }
        fallingCheck();
        if (Input.GetButton("Right"))
        {
            moveRight();
        }
        if (Input.GetButton("Left"))
        {

            moveLeft();
        }
        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }
        if (health == 4)
        {
            healthBar.GetComponent<HealthBarScript>().FourHP();
        }
        if (health == 3)
        {
            healthBar.GetComponent<HealthBarScript>().ThreeHP();
        }
        if (health == 2)
        {
            healthBar.GetComponent<HealthBarScript>().TwoHP();
        }
        if (health == 1)
        {
            healthBar.GetComponent<HealthBarScript>().OneHP();
        }
        if (health < 1)
        {
            eventSystem.GetComponent<EventScript>().GameOver();
        }
    }

    void moveLeft()
    {

        tempPos = character.transform.position;

        Vector3 newPos;
        newPos.x = transform.position.x - movementModifier;
        newPos.y = transform.position.y;
        newPos.z = transform.position.z;

        character.transform.position = Vector2.Lerp(transform.position, newPos, 1f);
        sprites.flipX = true;
    }

    void moveRight()
    {

        tempPos = character.transform.position;

        Vector3 newPos;
        newPos.x = transform.position.x + movementModifier;
        newPos.y = transform.position.y;
        newPos.z = transform.position.z;

        character.transform.position = Vector2.Lerp(transform.position, newPos, 1f);
        sprites.flipX = false;
    }
    void jump()
    {
        if (!isfalling)
        {
            characterBody.velocity = new Vector3(0, jumpModifier, 0);
        }
        else if (isfalling && !hasDoubleJumped && canDoubleJump)
        {
            characterBody.velocity = new Vector3(0, jumpModifier, 0);
            hasDoubleJumped = true;
        }
    }
    void fallingCheck()
    {
        if(characterBody.velocity.y != fallThresh)
        {
            isfalling = true;
        }
        else
        {
            isfalling = false;
            hasDoubleJumped = false;
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {

            health -= 1;
            col.gameObject.GetComponent<EnemyMovement>().dead = true;
        }

        if (col.gameObject.tag == "EnemyKillBox")
        {
            col.gameObject.transform.parent.GetComponent<EnemyMovement>().dead = true;
        }

        if (col.gameObject.tag == "LethalHazard")
        {
            health = 0;
        }

        if (col.gameObject.tag == "Hazard")
        {
            health -= 1;
        }

        if (col.gameObject.tag == "Coin")
        {
            score += 1;
            col.gameObject.SetActive(false);
        }
        if(col.gameObject.tag == "ColourChanger")
        {
            col.gameObject.SetActive(false);
        }
    }

    void colourCheck()
    {
        if (eventSystem.GetComponent<EventScript>().isColoured)
        {
            isColoured = true;
            sprites.sprite = newSprite;
        }
    }
}
