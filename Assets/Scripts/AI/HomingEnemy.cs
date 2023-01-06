using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : MonoBehaviour, IBasicEnemy, IDamagable
{
    //private float _hp;
    private float health;

    public void TakeDamage(int damage)
    {   
        Debug.Log("taking damage");
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DealDamage(float damage)
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    //public void TakeDamage(float damage)
    //{
    //    Debug.Log("Taking Damage");
    //}
}
