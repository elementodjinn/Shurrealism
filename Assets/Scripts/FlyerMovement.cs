using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerMovement : MonoBehaviour
{
    // horizontal move speed for the player
    public float moveSpeed = 5f;

    // gravity multiplier for high jumps (holding down the spacebar)
    // making it larger will cause high jumps to fall more quickly
    public float fallMultiplier = 2.5f;
    public float jumpVelocity = 10f;

    // rigidbody of the Player
    Rigidbody2D rb;

    bool canFlip = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
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
        rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        if (rb.velocity.y < -10f)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            canFlip = true;
        }
        if (rb.velocity.y > 5f) flip();

        Vector3 movement = new Vector3(dir, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

    }


    void flip()
    {
        if (canFlip)
        {
            dir = -dir;
            if (dir > 0) GetComponent<SpriteRenderer>().flipX = false;
            else GetComponent<SpriteRenderer>().flipX = true;
            canFlip = false;
        }
    }
}
