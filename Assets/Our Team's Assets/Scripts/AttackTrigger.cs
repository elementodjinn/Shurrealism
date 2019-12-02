using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && (col.CompareTag("Enemy") || col.CompareTag("Wall")))
        {
            col.gameObject.GetComponent<EnemyHealth>().takeDamage(1);
        }
    }
}
