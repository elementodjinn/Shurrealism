using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideGroundCheck : MonoBehaviour
{
    GameObject enemy;
    public bool isLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the parent of the object the Grounded script is on
        // and assigns it to enemy
        enemy = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // If enemy is touching the ground, isGrounded is set to True
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            
            if (isLeft)
            {
                if(enemy.GetComponent<EnemyMovement>() != null) enemy.GetComponent<EnemyMovement>().leftGrounded = true;
                else if (enemy.GetComponent<ChomperMovement>() != null) enemy.GetComponent<ChomperMovement>().leftGrounded = true;
                else if (enemy.GetComponent<badTripMovement>() != null) enemy.GetComponent<badTripMovement>().leftGrounded = true;
            }
            else
            {
                if (enemy.GetComponent<EnemyMovement>() != null) enemy.GetComponent<EnemyMovement>().rightGrounded = true;
                else if (enemy.GetComponent<ChomperMovement>() != null) enemy.GetComponent<ChomperMovement>().rightGrounded = true;
                else if (enemy.GetComponent<badTripMovement>() != null) enemy.GetComponent<badTripMovement>().rightGrounded = true;
            }
        }
    }

    // If enemy stops touching the ground, isGrounded is set to False
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (isLeft)
            {
                if (enemy.GetComponent<EnemyMovement>() != null) enemy.GetComponent<EnemyMovement>().leftGrounded = false;
                else if (enemy.GetComponent<ChomperMovement>() != null) enemy.GetComponent<ChomperMovement>().leftGrounded = false;
                else if (enemy.GetComponent<badTripMovement>() != null) enemy.GetComponent<badTripMovement>().leftGrounded = false;
            }
            else
            {
                if (enemy.GetComponent<EnemyMovement>() != null) enemy.GetComponent<EnemyMovement>().rightGrounded = false;
                else if (enemy.GetComponent<ChomperMovement>() != null) enemy.GetComponent<ChomperMovement>().rightGrounded = false;
                else if (enemy.GetComponent<badTripMovement>() != null) enemy.GetComponent<badTripMovement>().rightGrounded = false;
            }
        }
    }
}