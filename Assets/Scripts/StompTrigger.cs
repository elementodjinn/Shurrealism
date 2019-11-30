using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompTrigger : MonoBehaviour
{
    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<EnemyHealth>().takeDamage(1);
            rb.velocity = Vector2.up * 10;
        }
    }
}
