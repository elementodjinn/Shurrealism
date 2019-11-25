using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badAttack : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("owo");
        collision.gameObject.GetComponent<PlayerHealth>().DamagePlayer(1);
        
    }
}
