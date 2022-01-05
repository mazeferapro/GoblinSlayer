using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp;
    public void TakeDamage(int Damage)
    {
        if (hp <= 0) { Destroy(gameObject); }
        else { hp -= Damage; }
    }
}
