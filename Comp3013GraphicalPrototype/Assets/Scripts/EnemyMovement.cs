using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Vector3 tempPos;
    public GameObject enemy;
    public float movementModifier;
    public bool isLeft = true;
    public bool isActive = false;
    public bool dead = false;
    public GameObject player;
    [SerializeField] float playerCloseness;
    [SerializeField] float playerCloseness2;
    private GameObject eventSystem;
    public float closenessFactor;
    public bool isColoured = false;
    private SpriteRenderer sprites;
    [SerializeField] Sprite newSprite;

    // Start is called before the first frame update
    void Start()
    {
        movementModifier = movementModifier / 50;
        player = GameObject.Find("Character");
        eventSystem = GameObject.Find("EventSystem");
        sprites = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isColoured)
        {
            colourCheck();
        }

        closeCheck();

        if (isActive)
        {
            if (isLeft)
            {
                left();
            }
            else if (!isLeft)
            {
                right();
            }
        }


        if (dead)
        {
            Destroy(this.gameObject); 
        }
    }

    void closeCheck()
    {
        playerCloseness = player.transform.position.x - enemy.transform.position.x;
        playerCloseness2 = player.transform.position.y - enemy.transform.position.y;
        if(playerCloseness2 <= 0)
        {
            playerCloseness2 = playerCloseness2 * -1;
        }
        if (playerCloseness < closenessFactor && playerCloseness > 0 && playerCloseness2 < 1.5)
        {
            isActive = true;
            isLeft = false;
        }
        else if (playerCloseness < 0 && playerCloseness > -closenessFactor && playerCloseness2 < 1.5)
        {
            isActive = true;
            isLeft = true;
        }
        else
        {
            isActive = false;
        }
    }

    void left()
    {
        tempPos = enemy.transform.position;
        Vector3 newPos;
        newPos.x = transform.position.x - movementModifier;
        newPos.y = transform.position.y;
        newPos.z = transform.position.z;

        enemy.transform.position = Vector2.Lerp(transform.position, newPos, 1f);
        enemy.transform.GetComponent<SpriteRenderer>().flipX = false;
    }

    void right()
    {
        tempPos = enemy.transform.position;
        Vector3 newPos;
        newPos.x = transform.position.x + movementModifier;
        newPos.y = transform.position.y;
        newPos.z = transform.position.z;

        enemy.transform.position = Vector2.Lerp(transform.position, newPos, 1f);
        enemy.transform.GetComponent<SpriteRenderer>().flipX = true;
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
