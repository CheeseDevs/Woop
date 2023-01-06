using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdEnemy : MonoBehaviour, IDamagable
{
    [SerializeField]
    //private float _hp = 50f;
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

    //public void TakeDamage(float damage)
    //{
    //    _hp -= damage;
    //    Debug.Log("taking damage");
    //}

}
