using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Sprite[] HeartSprites;

    public Image HeartUI;

    [SerializeField] Transform spawnPoint;

    public int startingHealth = 3;
    public int currentHealth = 3;

    public float invulTime = 2.0f;
    public float invulRemaining = 0;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void DamagePlayer (int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            transform.position = spawnPoint.position;
            currentHealth = startingHealth;
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy" && invulRemaining < 0)
        {
            DamagePlayer(1);
            invulRemaining = invulTime;
        }
    }

    private void Update()
    {
        HeartUI.sprite = HeartSprites[currentHealth];
        invulRemaining -= Time.deltaTime;
    }
}
