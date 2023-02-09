using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemy : MonoBehaviour, IDamagable
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _health;
    [SerializeField]
    private float _maxHealth = 100f;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private Vector3 _startPoint;
    [SerializeField]
    private Vector3 _endPoint;
    [SerializeField]
    private float _duration;
    private bool _reached = false;

    [SerializeField]
    private bool _shouldShoot;
    [SerializeField]
    private float _fireRate;
    [SerializeField]
    private float _shotCounter;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    public Transform _firePoint;


    // Start is called before the first frame update

    void Start()
    {
        _startPoint = transform.position + _startPoint;
        _endPoint = transform.position + _endPoint;
        _reached = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            DealDamage(30);
        }
    }

    // IBasicEnemy
    public void DealDamage(float damage)
    {
        PlayerMovement.instance.TakeDamage(damage);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Move()
    {
        if (_reached)
        {
            StartCoroutine(RepeatLerp());
            _reached = false;
        }

    }

    public void TakeDamage(float damage)
    {
        
        if (_health >= 0)
        {
            _health = _health - damage;
        }

        else 
        {
            Die();
        }
       
    }

    public void Heal(float damage)
    {
        
        if (_health <= _maxHealth)
        {
            _health = (_health + damage);
            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }
        }
       
    }

    IEnumerator RepeatLerp()
    {
        float timeElapsed = 0;
        while (timeElapsed < _duration)
        {
            transform.position = Vector3.Lerp(_startPoint, _endPoint, timeElapsed / _duration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        Vector3 temp = transform.position;
        temp = _endPoint;
        _endPoint = _startPoint;
        _startPoint = temp;
        _reached = true;
        Debug.Log(_endPoint + "      "+ _startPoint);
    }

    public void Shoot()
    {
        if (_shouldShoot)
        {
            _shotCounter -= Time.deltaTime;
            if (_shotCounter <= 0 && Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) <= 15)
            {
                Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
                _shotCounter = _fireRate;
            }
        }

    }

}
