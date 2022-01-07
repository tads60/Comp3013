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
    public float closenessFactor;

    // Start is called before the first frame update
    void Start()
    {
        movementModifier = movementModifier / 500;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (playerCloseness < closenessFactor && playerCloseness > 0)
        {
            isActive = true;
            isLeft = false;
        }
        else if (playerCloseness < 0 && playerCloseness > -closenessFactor)
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
}
