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

    //will gain 3x speed when contacting enemy if true
    public bool charger = false;

    //will jump away when contacting enemy if true
    public bool coward = false;

    public bool rightJumper = false;
    public bool leftJumper = false;

    // rigidbody of the Player
    Rigidbody2D rb;

    /*
     SOME NOTES:
     basicenemy can be used as the one on fire
     if you set an enemy's hp to 420 they're invincible
         */
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // True if the player is touching the ground
    public bool leftGrounded = false;
    public bool rightGrounded = false;

    bool canFlip = true;

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
        if(!(leftGrounded || rightGrounded))
        {
            if (!GetComponent<SpriteRenderer>().flipX) dir = 1;
            else dir = -1;
        }
        else if ( ((dir > 0 && !rightGrounded) || (dir < 0 && !leftGrounded)))
        {
            if ((!leftGrounded && leftJumper) || (!rightGrounded && rightJumper)) jump();
            else flip();
        }
        else if (leftGrounded && rightGrounded) canFlip = true;

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
            if (charger)
            {
                charge = 3;
                GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (coward)
            {
                flip();
                Vector3 movement = new Vector3(dir, 0f, 0f);
                transform.position += movement * Time.deltaTime * 3 * moveSpeed;
                jump();
            }
            else flip();
        }
        else
        {
            flip();
        }
    }

    void flip()
    {
        if (canFlip)
        {
            dir = -dir;
            if (dir > 0) GetComponent<SpriteRenderer>().flipX = false;
            else GetComponent<SpriteRenderer>().flipX = true;
            if (charger)
            {
                charge = 1;
                GetComponent<SpriteRenderer>().color = Color.white;
            }
            canFlip = false;
        }
    }

    void jump()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
    }
}
