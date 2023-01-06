using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using IDamagable;


public class Enemy : MonoBehaviour, IDamagable
{
    public int health=100;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(health);
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= (int)damage;

        healthBar.SetHealth(currentHealth);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
