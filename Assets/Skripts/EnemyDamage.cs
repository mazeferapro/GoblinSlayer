using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int Health;
    public void TakeDamage(int Damage)
    {
        if (Health <= 0) { Destroy(gameObject); }
        else { Health -= Damage; }
    }
}
