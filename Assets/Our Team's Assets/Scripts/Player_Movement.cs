using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // horizontal move speed for the player
    public float moveSpeed = 5f;

    // vertical jump velocity for the player
    // making it larger will cause jumps to be higher
    public float jumpVelocity = 5f;

    // gravity multiplier for high jumps (holding down the spacebar)
    // making it larger will cause high jumps to fall more quickly
    public float fallMultiplier = 2.5f;
    // gravity multiplier for low jumps (single tap)
    // making it larger will cause low jumps to be lower
    public float lowJumpMultiplier = 2f;

    public Animator anim;

    // rigidbody of the Player
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // True if the player is touching the ground
    public bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the Player is falling, apply gravity multiplier
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        // if the Player is jumping but not holding the Jump button, apply low jump gravity multiplier
        else if (rb.velocity.y > 0 && !(Input.GetKey("w") || Input.GetButton("Jump")))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        Jump();

        // gets the location of the player and updates it constantly
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        anim.SetFloat("Speed", Mathf.Abs(movement.x));
        anim.SetBool("Jumping", (Input.GetKey("w") || Input.GetButton("Jump")));

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector2(-0.5917852f, transform.localScale.y);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector2(0.5917852f, transform.localScale.y);
        }
    }

    // if the Jump button is pushed, apply jump velocity
    void Jump()
    {
        if ((Input.GetKeyDown("w") || Input.GetButtonDown("Jump")) && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        }
        
    }
}
