using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperMovement : MonoBehaviour
{
    // horizontal move speed for the player
    public float moveSpeed = 10f;

    // gravity multiplier for high jumps (holding down the spacebar)
    // making it larger will cause high jumps to fall more quickly
    public float fallMultiplier = 2.5f;
    // rigidbody of the Player
    Rigidbody2D rb;

    public float moveTimer = 3f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // True if the player is touching the ground
    public bool leftGrounded = false;
    public bool rightGrounded = false;

    bool canFlip = true;
    public int dir = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponent<SpriteRenderer>().flipX) dir = 1;
        else dir = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!(leftGrounded || rightGrounded))
        {
            if (!GetComponent<SpriteRenderer>().flipX) dir = 1;
            else dir = -1;
        }
        else if (((dir > 0 && !rightGrounded) || (dir < 0 && !leftGrounded))) flip();
        else if (leftGrounded && rightGrounded) canFlip = true;

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        moveTimer -= Time.deltaTime;
        if (moveTimer <= 0)
        {
            Vector2 movement = new Vector2(dir, 0f);
            rb.velocity += movement * moveSpeed;
            moveTimer = 5f;
        }
    }

    void flip()
    {
        rb.velocity = new Vector2(0f, 0f);
        if (canFlip)
        {
            dir = -dir;
            if (dir > 0) GetComponent<SpriteRenderer>().flipX = false;
            else GetComponent<SpriteRenderer>().flipX = true;
            canFlip = false;
        }
    }
}
