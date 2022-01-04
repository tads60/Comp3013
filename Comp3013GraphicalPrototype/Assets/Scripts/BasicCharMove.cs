using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharMove : MonoBehaviour
{
    private Vector3 tempPos;
    public GameObject character;
    public float movementModifier;
    public float jumpModifier;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Right"))
        {

            tempPos = character.transform.position;

            Vector3 newPos;
            newPos.x = transform.position.x + movementModifier;
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;

            character.transform.position = Vector2.Lerp(transform.position, newPos, 1f);
        }
        if (Input.GetButton("Left"))
        {

            tempPos = character.transform.position;

            Vector3 newPos;
            newPos.x = transform.position.x - movementModifier;
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;

            character.transform.position = Vector2.Lerp(transform.position, newPos, 1f);
        }
        if (Input.GetButtonDown("Jump"))
        {

            tempPos = character.transform.position;
            if (tempPos.y <  -2.8)
            {
                Vector3 newPos;
                newPos.x = transform.position.x;
                newPos.y = transform.position.y + jumpModifier;
                newPos.z = transform.position.z;

                character.transform.position = Vector2.Lerp(transform.position, newPos, 1f);
            }
            //jumpCode
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
    }
}
