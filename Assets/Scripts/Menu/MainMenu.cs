using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator gunAnim;
   public void Play()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GunAnim();
   }

    public void GunAnim()
    {
        gunAnim.SetTrigger("Shoot");
    }

    public void Instruction()
    {
        GunAnim();
    }
   public void Exit()
   {
        Application.Quit();
        GunAnim();
   }
}
