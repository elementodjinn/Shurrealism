using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior: MonoBehaviour
{
    public float speed = 100f;
    public Rigidbody2D rb;
    public GameObject target;

    void Start()
    {
        transform.LookAt(target.transform.position, Vector3.forward);
        rb.velocity = -transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
