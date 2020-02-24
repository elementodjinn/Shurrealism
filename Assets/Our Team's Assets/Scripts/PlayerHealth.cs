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
    public void HealPlayer (int health)
    {
        currentHealth += health;
        if (currentHealth > 3)
        {
            currentHealth = 3;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HealthPowerup")
        {
            HealPlayer(1);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "FullHealthPowerup")
        {
            HealPlayer(3);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Respawn")
        {
            spawnPoint = collision.transform;
        }
        if (collision.tag == "InstantDeath")
        {
            DamagePlayer(3);
            invulRemaining = invulTime;
        }
        if (collision.tag == "Portal")
        {
            transform.position = spawnPoint.position;
        }
        if (collision.tag == "Checkpoint")
        {
            spawnPoint.position = transform.position;
        }
    }

    private void Update()
    {
        HeartUI.sprite = HeartSprites[currentHealth];
        invulRemaining -= Time.deltaTime;
    }
}
