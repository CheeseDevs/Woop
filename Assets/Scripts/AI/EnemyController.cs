using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    [SerializeField]
    private float _health;
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




    public float playerRange = 10f;
    public float speed;
    public Rigidbody2D rb;




    public void DealDamage(float damage)
    {

    }


    public void TakeDamage(float damage)
    {
        for (int i = 0; i < damage; i++)
        {
            if (_health >= 0)
            {
                _health = _health - 1;
            }
            else
            {
                Die();
            }
        }
    }

    private void Die()
    {
        // Instantiate explosion
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) <= playerRange)
        {
            Vector3 playerDir = PlayerMovement.instance.transform.position - transform.position;
            rb.velocity = playerDir * speed;

            if (_shouldShoot)
            {
                _shotCounter -= Time.deltaTime;
                if (_shotCounter <= 0)  
                {
                    Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
                    _shotCounter = _fireRate;
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
