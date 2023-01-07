using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    // public static bool isDead = false;
    public GameObject DeathMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        // gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void toggleDeathMenu()
    {
        DeathMenuCanvas.SetActive(true);
    }

    public void Retry()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DeathMenuCanvas.SetActive(false);
        PauseMenu.Paused = false;
    }

    public void Exit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        PauseMenu.Paused = false;
    }
}
