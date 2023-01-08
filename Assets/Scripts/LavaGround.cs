using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaGround : MonoBehaviour
{

    [SerializeField] private float _damageAmount = 5f;
    [SerializeField] AudioSource lavaSoundEffect;
    private float _waitTime = .3f;
    private float _counter = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DealDamage()
    {
        if (_counter <= _waitTime)
        {
            _counter += Time.deltaTime;
        }
        else
        {
            PlayerMovement.instance.TakeDamage(_damageAmount);
            _counter = 0;
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {   
            lavaSoundEffect.Play();
            DealDamage();
            Debug.Log("damaging player");
        }
    }

}
