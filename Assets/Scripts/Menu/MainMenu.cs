using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator gunAnim;
    [SerializeField] GameObject _Instruction;
    [SerializeField] GameObject _MainMenu;
    public void Play()
    {
        StartCoroutine(PlayGame());
    }

    public void GunAnim()
    {
        Debug.Log("Anim played");
        gunAnim.SetTrigger("Shoot");
    }

    public void Instruction()
    {
        StartCoroutine(HowToPlay());
    }
    public void Exit()
    {
        StartCoroutine(ExitGame());
    }

    public IEnumerator HowToPlay()
    {
        GunAnim();
        yield return new WaitForSeconds(.2f);
        Debug.Log("How to");
        _Instruction.SetActive(true);
        _MainMenu.SetActive(false);
    }
    public IEnumerator PlayGame()
    {
        GunAnim();
        yield return new WaitForSeconds(.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public IEnumerator ExitGame()
    {
        GunAnim();
        yield return new WaitForSeconds(.2f);
        Application.Quit();
    }
}
