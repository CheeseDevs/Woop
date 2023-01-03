using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdEnemy : MonoBehaviour, IDamagable
{
    [SerializeField]
    private float _hp = 50f;


    public void TakeDamage(float damage)
    {
        _hp -= damage;
        Debug.Log("taking damage");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
