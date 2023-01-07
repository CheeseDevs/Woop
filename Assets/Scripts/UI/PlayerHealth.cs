using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int health;

    //public int maxArmor;
    //private int armor;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        CanvasManager.Instance.UpdateHealth(health);
        //armor = maxArmor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            DamagePlayer(30);
            Debug.Log("Player has been Damaged");
        }   
    }

    public void DamagePlayer(int damage)
    {
        // if(armor > 0)
        // {
        //     if(armor >= damage)
        //     {
        //         armor -= damage;
        //     }
        //     else if(armor < damage)
        //     {
        //         int remainingDamage;

        //         remainingDamage = damage - armor;

        //         armor = 0;

        //         health -= remainingDamage;
        //     }
        // }
        // else
        // {
        //     health -= damage;
        // }

        health -= damage;

        if (health <= 0)
        {
            Debug.Log("Player Died");

            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }

        CanvasManager.Instance.UpdateHealth(health);
        //CanvasManager.Instance.UpdateHealth(armor);
    
    }

    // public void GiveHealth(int amount, GameObject pickup)
    // {
    //     if(health < maxHealth)
    //     {
    //         health += amount;
    //         destroy(pickup);
    //     }

    //     if(health > maxHealth)
    //     {
    //         health = maxHealth;
    //     }

    //     CanvasManager.Instance.UpdateHealth(health);
    // }

    //    public void GiveHealth(int amount, GameObject pickup)
   
    // {
    //     if(health < maxArmor)
    //     {
    //         armor += amount;
    //         destroy(pickup);
    //     }

    //     if(armor > maxArmor)
    //     {
    //         armor = maxArmor;
    //     }

    //     CanvasManager.Instance.UpdateHealth(armor);
    // }
}
