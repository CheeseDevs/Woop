using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearEnemy : FloatingEnemy
{
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
        
    }

    // Update is called once per frame


    public void Shoot()
    {
        _shotCounter -= Time.deltaTime;
        if (_shotCounter <= 0)
        {
            Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
            _shotCounter = _fireRate;
        }
    }
}
