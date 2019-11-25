﻿using System.Collections;
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

    Rigidbody2D rb;
    public GameObject target;

    int state = 0;//0=moving, 1=attacking
    public Collider2D attack;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public int dir = 1;

    float attackDuration = 2f;

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
                if (target.transform.position.x < transform.position.x) {
                    dir = -1;
                    transform.localScale = new Vector2(-0.9906484f, transform.localScale.y);
                }
                else if(target.transform.position.x > transform.position.x)
                {
                    dir = 1;
                    transform.localScale = new Vector2(0.9906484f, transform.localScale.y);
                }
                // if the Player is falling, apply gravity multiplier
                if (rb.velocity.y < 0) rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

                // gets the location of the player and updates it constantly
                Vector3 movement = new Vector3(dir, 0f, 0f);
                transform.position += movement * Time.deltaTime * moveSpeed;

                if (Mathf.Abs(Vector3.Distance(target.transform.position, transform.position)) < 3f) state = 1;
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

    void jump()
    {
        rb.velocity = Vector2.up * jumpVelocity;
    }
}
