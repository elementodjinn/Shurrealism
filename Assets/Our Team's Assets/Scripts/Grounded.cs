using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{

    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the parent of the object the Grounded script is on
        // and assigns it to Player
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // If Player is touching the ground, isGrounded is set to True
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" | collision.collider.tag == "PunchableBlock")
        {
            Player.GetComponent<Player_Movement>().isGrounded = true;
        }
    }

    // If player stops touching the ground, isGrounded is set to False
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" | collision.collider.tag == "PunchableBlock")
        {
            Player.GetComponent<Player_Movement>().isGrounded = false;
        }
    }

}
