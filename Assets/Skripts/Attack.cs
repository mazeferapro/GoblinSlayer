using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float AttackSpeed;
    public float StartAttackSpeed;
    private int _Vampiric;
    public int VampiricChance;

    public Transform AttackPos;
    public LayerMask Enemy;
    public float AttackRange;
    public int Damage;
    public Animator anim;

    void Update()
    {
        _Vampiric = VampiricChance * Damage / 100;
        if (Input.GetMouseButton(0)) 
        {
            if (AttackSpeed <= 0)
            {
                anim.SetTrigger("Attack");
            }
            AttackSpeed = StartAttackSpeed;
        }
        else
        {
            AttackSpeed -= Time.deltaTime;
        }
    }

    public void OnAttack()
    {
        
                Collider2D[] enemies = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, Enemy);
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<EnemyDamage>().TakeDamage(Damage);
                    GetComponent<Health>().Vampiric(_Vampiric);   
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange);
    }
}