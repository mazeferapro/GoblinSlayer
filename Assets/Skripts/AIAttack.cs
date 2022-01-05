using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : MonoBehaviour
{
    public LayerMask Player;
    public int Damage;
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            trig.GetComponent<Health>().TakeDamage(Damage);
        }
    }
}
