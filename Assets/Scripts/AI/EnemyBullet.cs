using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private float _damageAmouunt;
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private Rigidbody2D _rb;

    private Vector3 _playerDir;


    // Start is called before the first frame update
    void Start()
    {
        _playerDir = PlayerMovement.instance.transform.position - transform.position;
        _playerDir.Normalize();
        _playerDir = _playerDir * _bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = _playerDir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Dealing player");
            PlayerMovement.instance.TakeDamage(_damageAmouunt);
            Destroy(gameObject);
        }
        
    }
}
