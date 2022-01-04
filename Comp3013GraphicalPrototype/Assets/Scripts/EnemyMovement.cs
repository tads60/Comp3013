using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Vector3 tempPos;
    public GameObject enemy;
    public float movementModifier;
    public bool isLeft = true;
    public bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        movementModifier = movementModifier / 500;
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = enemy.transform.position;
        Vector3 newPos;
        newPos.x = transform.position.x - movementModifier;
        newPos.y = transform.position.y;
        newPos.z = transform.position.z;

        enemy.transform.position = Vector2.Lerp(transform.position, newPos, 1f);
        if (dead)
        {
            Destroy(this.gameObject);
        }
    }
}
