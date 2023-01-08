using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{

    public TextMeshProUGUI health;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI ammo;

    public Image healthIndicator;

    public Sprite health1;
    public Sprite health2;
    public Sprite health3;
    public Sprite health4;

    public GameObject redKey;
    public GameObject blueKey;
    public GameObject greenKey;
    public GameObject purpleKey;

    private static CanvasManager _instance;
    public static CanvasManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            healthIndicator.sprite = health1;
        }
    }

    public void UpdateHealth(float healthValue)
    {
        health.text = healthValue.ToString() + "%";
        UpdateHealthIndicator(healthValue);
    }

    // public void UpdateArmor(int armorValue)
    // {
    //     armor.text = armorValue.ToString() + "%";
    // }

    public void UpdateAmmo(float ammoValue)
    {
        ammo.text = ammoValue.ToString();
    }

    public void UpdateHealthIndicator(float healthValue)
    {
        if (healthValue >= 66)
        {
            healthIndicator.sprite = health1;
        }
        if (healthValue <= 66 && healthValue >= 33)
        {
            healthIndicator.sprite = health2;
        }
        if (healthValue < 33 && healthValue>0)
        {
            healthIndicator.sprite = health3;
        }
        if (healthValue <= 0)
        {
            healthIndicator.sprite = health4;
        }
    }

    public void UpdateKeys(string keyColor)
    {
        if (keyColor == "red")
        {
            redKey.SetActive(true);
        }
        if (keyColor == "green")
        {
            greenKey.SetActive(true);
        }
        if (keyColor == "blue")
        {
            blueKey.SetActive(true);
        }
        if (keyColor == "purple")
        {
            purpleKey.SetActive(true);
        }
    }

    public void ClearKeys()
    {
        redKey.SetActive(false);
        greenKey.SetActive(false);
        blueKey.SetActive(false);
        purpleKey.SetActive(false);
    }

}
