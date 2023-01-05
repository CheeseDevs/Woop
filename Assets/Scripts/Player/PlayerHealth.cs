using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int armor = 50;
    //public slider healthBar;
    //public slider armorBar;

    void Update()
    {
        // Update the value of the health and armor bars:
       // healthBar.value = health;
        //armorBar.value = armor;
    }

    public void TakeDamage(int damage)
    {
        // Subtract damage from armor first, if any armor remains:
        if (armor > 0)
        {
            armor -= damage;
            if (armor < 0)
            {
                // If armor has been depleted, subtract the remaining damage from health:
                health += armor;
                armor = 0;
            }
        }
        else
        {
            // If no armor remains, subtract damage from health directly:
            health -= damage;                                            
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }
}
