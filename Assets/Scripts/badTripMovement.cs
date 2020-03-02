using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badTripMovement : MonoBehaviour
{
    // horizontal move speed for the player
    public float moveSpeed = 5f;

    // gravity multiplier for high jumps (holding down the spacebar)
    // making it larger will cause high jumps to fall more quickly
    public float fallMultiplier = 2.5f;
    public float jumpVelocity = 5f;

    Rigidbody2D rb; //own rb
    public GameObject target;

    int state = 0;//0=moving, 1=attacking
    public Collider2D attack;
    public float scale = 1.465169f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
    }

    public int dir = 1;

    float attackDuration = 2f;
    float attackCooldown = 4f;
    public bool leftGrounded = true;
    public bool rightGrounded = true;
    bool canFlip = false;
    bool attackAnim = false;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponent<SpriteRenderer>().flipX) dir = 1;
        else dir = -1;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state) {
            case 0:
                attack.enabled = false;
                if (((dir > 0 && !rightGrounded) || (dir < 0 && !leftGrounded)))
                {
                    flip();
                }
                if (rightGrounded && leftGrounded) canFlip = true;
                // if falling, apply gravity multiplier
                if (rb.velocity.y < 0) rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

                // gets the location of the player and updates it constantly
                Vector3 movement = new Vector3(dir, 0f, 0f);
                transform.position += movement * Time.deltaTime * moveSpeed;

                attackCooldown -= Time.deltaTime;
                if (attackCooldown < .5 && !attackAnim)
                {
                    anim.SetTrigger("Attack");
                    attackAnim = true;
                }
                if (attackCooldown < 0)// && leftGrounded && rightGrounded)
                {
                    attackAnim = false;
                    state = 1;
                    attackCooldown = 5f;
                }
                break;
            case 1:
                attack.enabled = true;
                attackDuration -= Time.deltaTime;
                if(attackDuration <= 0)
                {
                    attackDuration = 2f;
                    state = 0;
                }
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall" || collision.collider.tag == "Ground")
        {
            Vector3 movement = new Vector3(-dir, 0f, 0f);
            transform.position += movement * Time.deltaTime * moveSpeed * 20;
            canFlip = true;
            flip();
            //if(collision.collider.tag == "Wall") jump();
        }
    }

    void jump()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
    }

    void flip()
    {
        if (canFlip)
        {
            dir = -dir;
            if (dir > 0) transform.localScale = new Vector2(scale, transform.localScale.y);
            else transform.localScale = new Vector2(-scale, transform.localScale.y);
            canFlip = false;
        }
    }
}
