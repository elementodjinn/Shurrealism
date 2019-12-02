using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
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
}
