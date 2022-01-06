using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    private int HP;
    public int maxHP;

    public HealthBar healthBar;
    void Start()
    {
        HP = maxHP;
        healthBar.SetMaxHealth(maxHP);
    }
    public void TakeDamage(int Damage)
    {
        if (HP <= 0) { Destroy(gameObject); }
        else
        { 
            HP -= Damage;
            healthBar.SetHealth(HP);
        }
    }
}
