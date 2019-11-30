using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int hp = 1;
    public void takeDamage(int dmg)
    {
        if (hp == 420) return;
        hp -= dmg;
        if (hp <= 0) Destroy(gameObject);
    }
}
