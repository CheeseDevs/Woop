using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasRed, hasGreen, hasBlue, hasPurple;
    // Start is called before the first frame update
    void Start()
    {
        CanvasManager.Instance.ClearKeys();
    }


}
