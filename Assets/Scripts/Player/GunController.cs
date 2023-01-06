using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{   
    [SerializeField]
    private BoxCollider _bulletPrefab;
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
    [SerializeField]
    private GameObject bulletPrefab;

    public EnemyPool enemyPool;
    public float bulletVelocity = 1000;
    public float bulletLifetime = 5;


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
        //bullet
        Debug.Log("Fire method called");

        // 1. Create a bullet prefab:
        // GameObject bulletPrefab = Resources.Load("Assets/AI_assets/Prefabs/BulletPrefab.prefab") as GameObject;
        // if (bulletPrefab == null)
        // {
        //     Debug.Log("bullet nai");
        // }
        // 2. Add a firing point to your gun:
        Transform firingPoint = transform.Find("FiringPoint");

        // 3. Instantiate the bullet prefab when the gun is fired:
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);

        // 4. Give the bullet velocity:
        bullet.GetComponent<Rigidbody>().AddForce(firingPoint.forward * bulletVelocity, ForceMode.VelocityChange);

        // 5. Destroy the bullet after a certain amount of time:
        Destroy(bullet, bulletLifetime);
        //if (enemyPool != null && enemyPool.enemypool != null)
        //{
         //   foreach(var damagable in enemyPool.enemypool)
         //   {
         //       if (damagable != null)
         //       {
         //           damagable.GetComponent<IDamagable>().TakeDamage(3);
         //       }
         //   }
        //}

        //_nextTimeToShoot = Time.time + _fireRate;
    }                                                  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (enemyPool != null)
            {
                enemyPool.AddItem(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (enemyPool != null)
            {
                enemyPool.RemoveItem(other.gameObject);
            }
        }
    }
}
