using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour, IPickable
{
    [SerializeField] private bool isRedKey;
    [SerializeField] private bool isGreenKey;
    [SerializeField] private bool isPurpleKey;
    [SerializeField] private bool isBlueKey;

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void GiveEffect()
    {
        if (isRedKey)
        {
            PlayerMovement.instance.transform.GetComponent<PlayerInventory>().HasRedKey = true;
            CanvasManager.Instance.UpdateKeys(keyColor:"red");
        }
        else if (isGreenKey)
        {
            PlayerMovement.instance.transform.GetComponent<PlayerInventory>().HasGreenKey = true;
            CanvasManager.Instance.UpdateKeys(keyColor:"green");
        }
        else if (isPurpleKey)
        {
            PlayerMovement.instance.transform.GetComponent<PlayerInventory>().HasPurpleKey = true;
            CanvasManager.Instance.UpdateKeys(keyColor:"purple");
        }
        else if (isBlueKey)
        {
            PlayerMovement.instance.transform.GetComponent<PlayerInventory>().HasBlueKey = true;
            CanvasManager.Instance.UpdateKeys(keyColor:"blue");
        }
        DestroySelf();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GiveEffect();
        }
    }
}

