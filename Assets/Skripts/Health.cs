using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float HP;
    public float maxHP;
    private float Cooldown;
    private float RegenerationPerSeconds = 1f;
    public float StartCooldown;
    public float RegenPoint;
    public int Usability;
    private float ArmorDamage;
    public float Armor;
    public float PasiveRegeneration;


    public HealthBar healthBar;
    void Start()
    {
        HP = maxHP;
        healthBar.SetMaxHealth(maxHP);
    }

    public void USB(int _Usability)
    {
        Usability += _Usability;
    }

    void Update()
    {
        if (Usability > 0)
        {
            if (Cooldown <= 0 && Input.GetKey(KeyCode.Z))
            {
                Healing(RegenPoint);
                Usability--;
                Cooldown = StartCooldown;
            }
            else { Cooldown -= Time.deltaTime; }
        }
        else { Cooldown = 0; }

        if (RegenerationPerSeconds <= 0)
        {
            Healing(PasiveRegeneration);
            RegenerationPerSeconds = 1f;
        }
        else { RegenerationPerSeconds -= Time.deltaTime; }
        
    }


    public void TakeDamage(float Damage)
    {
        ArmorDamage = Damage - Armor;
        if (ArmorDamage <= 0) { ArmorDamage = 0; }
        HP -= ArmorDamage;
        healthBar.SetHealth(HP);
        if (HP <= 0) { Destroy(gameObject); }
    }

    public void Healing(float _Healing)
    {
        HP += _Healing;
        healthBar.SetHealth(HP);
        if (HP > maxHP) { HP = maxHP; }
        if (HP <= 0) { Destroy(gameObject); }
    }
}
