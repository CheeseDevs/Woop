using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance {get; private set;}
    // Start is called before the first frame update

    public static float timer;
    public static bool isStandard;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            timer = 0f;
            isStandard = true;
        }
        else
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Timer: " + timer);
        Debug.Log("Standard: " + isStandard);
        timer = (timer + Time.deltaTime) % 20;

        if (timer <= 14)
        {
            isStandard = true;
        }

        else isStandard = false;
    }
}
