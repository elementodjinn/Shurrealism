using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    const int damage = 100;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        
    }


    /*
     *
     *
     *
     *
     * private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<EnemyHealth>().takeDamage(1);
        }
        if (col.isTrigger != true && col.CompareTag("PunchableBlock"))
        {
            Console.WriteLine(col.tag);
            Destroy(col.gameObject);
        }
    }
     *
     *
     *
     *
     * */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        EnemyHealth temp = collision.GetComponent<EnemyHealth>();
        if (temp)
            temp.takeDamage(damage);
        Destroy(gameObject);
    }

   


}
