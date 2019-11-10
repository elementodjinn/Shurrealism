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
    public float jumpVelocity = 5f;

    public bool charger = false;
    public bool rightJumper = false;
    public bool leftJumper = false;

    // rigidbody of the Player
    Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // True if the player is touching the ground
    public bool leftGrounded = false;
    public bool rightGrounded = false;

    int charge = 1;

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
        if(leftGrounded && rightGrounded)
        {
            if (!GetComponent<SpriteRenderer>().flipX) dir = 1;
            else dir = -1;
        }
        else if ((leftGrounded || rightGrounded) && ((dir > 0 && !rightGrounded) || (dir < 0 && !leftGrounded)))
        {
            if ((!leftGrounded && leftJumper) || (!rightGrounded && rightJumper)) jump();
            else flip();
            
        }
        // if the Player is falling, apply gravity multiplier
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        // gets the location of the player and updates it constantly
        Vector3 movement = new Vector3(dir * charge, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            if (!charger) flip();
            else
            {
                charge = 3;
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy" && charger)
        {
            charge = 1;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void flip()
    {
        dir = -dir;
        if (dir > 0) GetComponent<SpriteRenderer>().flipX = false;
        else GetComponent<SpriteRenderer>().flipX = true;
    }

    void jump()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
    }
}
