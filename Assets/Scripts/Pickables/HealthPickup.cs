using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour, IPickable
{
    public void DestroySelf()
    {
        // add sound and effects
        Destroy(gameObject);
    }

    public void GiveEffect()
    {
        PlayerMovement.instance.AddHealth(30f);
        DestroySelf(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GiveEffect();
        }
    }
}
