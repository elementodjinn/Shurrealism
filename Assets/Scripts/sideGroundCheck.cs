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
                try { enemy.GetComponent<EnemyMovement>().leftGrounded = true; }
                catch { enemy.GetComponent<ChomperMovement>().leftGrounded = true; }
            }
            else
            {
                try { enemy.GetComponent<EnemyMovement>().rightGrounded = true; }
                catch { enemy.GetComponent<ChomperMovement>().rightGrounded = true; }
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
                try { enemy.GetComponent<EnemyMovement>().leftGrounded = false; }
                catch { enemy.GetComponent<ChomperMovement>().leftGrounded = false; }
            }
            else
            {
                try { enemy.GetComponent<EnemyMovement>().rightGrounded = false; }
                catch { enemy.GetComponent<ChomperMovement>().rightGrounded = false; }
            }
        }
    }
}