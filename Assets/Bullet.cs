using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletVelocity = 50f;
    public float bulletLifetime = 3f;
    public int damage = 10;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.forward * bulletVelocity;
        Destroy(gameObject, bulletLifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<IDamagable>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
