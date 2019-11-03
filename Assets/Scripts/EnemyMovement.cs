using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // horizontal move speed for the player
    public float moveSpeed = 5f;

    // gravity multiplier for high jumps (holding down the spacebar)
    // making it larger will cause high jumps to fall more quickly
    public float fallMultiplier = 2.5f;

    // rigidbody of the Player
    Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // True if the player is touching the ground
    public bool leftGrounded = false;
    public bool rightGrounded = false;

    public int dir = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!leftGrounded && !rightGrounded) dir = 0;
        else if (leftGrounded && rightGrounded)
        {
            if (!GetComponent<SpriteRenderer>().flipX) dir = 1;
            else dir = -1;
        }
        if ((dir > 0 && !rightGrounded) || (dir < 0 && !leftGrounded))
        {
            dir = -dir;
            if (dir > 0) GetComponent<SpriteRenderer>().flipX = false;
            else GetComponent<SpriteRenderer>().flipX = true;
        }
        // if the Player is falling, apply gravity multiplier
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        // gets the location of the player and updates it constantly
        Vector3 movement = new Vector3(dir, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

    }
}
