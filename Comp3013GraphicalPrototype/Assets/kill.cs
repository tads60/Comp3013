using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour
{
    void onTriggerEnter(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            transform.root.gameObject.GetComponent<EnemyMovement>().dead = true;
        }
    }
}
