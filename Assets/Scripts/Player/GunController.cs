using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private BoxCollider _gunTrigger;
    [SerializeField]
    private float _range = 20;
    [SerializeField]
    private float _verticalRange = 20;
    [SerializeField]
    private float _fireRate = 1;
    [SerializeField]
    private float _nextTimeToShoot = 0;

    public EnemyPool enemyPool;

    // Start is called before the first frame update
    void Start()
    {
        _gunTrigger.size = new Vector3(1, _verticalRange, _range);
        _gunTrigger.center = new Vector3(0, 0, .5f*_range);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > _nextTimeToShoot)
        {
            Fire();
        }
        
    }

    void Fire()
    {
        foreach(var damagable in enemyPool.enemypool)
        {
            damagable.GetComponent<IDamagable>().TakeDamage(3);
        }

        _nextTimeToShoot = Time.time + _fireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyPool.AddItem(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyPool.RemoveItem(other.gameObject);
        }
    }
}
