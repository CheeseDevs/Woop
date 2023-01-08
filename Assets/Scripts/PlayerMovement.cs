using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDamagable
{

    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maxHealth = 100f;



    public static PlayerMovement instance;



    public Rigidbody2D theRB;

    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity = 1f;
    public Camera viewCam;

    public GameObject bulletImpact;
    public int currentAmmo;
    public Animator gunAnim;

    [SerializeField]
    public static bool isDead;

    public GameObject deathMenu;
    public GameObject hud;

    private void Awake()
    {
        instance = this;
        isDead = false;
    }

    void start(){
       
        _currentHealth = _maxHealth;
        
        Cursor.lockState = CursorLockMode.Locked;

    }
    void Update()
    {       
        Debug.Log(_currentHealth);
        if (!PauseMenu.Paused && !isDead)
        {
            //Player Movement
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector3 moveHorizontal = transform.up * -moveInput.x;
            Vector3 moveVertical = transform.right * moveInput.y;
            theRB.velocity = (moveHorizontal+moveVertical) * moveSpeed;
            //Camera Movement 
            moveInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - moveInput.x);
            viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, moveInput.y, 0f));
            
            //Shooting
            if(Input.GetMouseButtonDown(0))
            {   
                if(currentAmmo > 0)
                {
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log("Shooting at" + hit.transform.name);
                        Instantiate(bulletImpact, hit.point, transform.rotation);
                        if (hit.transform.CompareTag("Enemy"))
                        {
                            hit.transform.parent.GetComponent<IDamagable>().TakeDamage(30);
                            
                        }
                    }
                    else
                    {
                        Debug.Log("Nothing");
                    }
                    currentAmmo--;
                    hud.GetComponent<CanvasManager>().UpdateAmmo(currentAmmo);
                    gunAnim.SetTrigger("Shoot");
                }
            }

            if (_currentHealth <= 0)
            {
                isDead = true;  
            }
        }
        else if (isDead)
        {
            theRB.velocity = Vector3.zero;
            deathMenu.GetComponent<DeathMenu>().toggleDeathMenu(); 
        }
        else 
        {
            theRB.velocity = Vector3.zero;
        }
        

    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth > 0)
        {
            _currentHealth = _currentHealth - damage;
            hud.GetComponent<CanvasManager>().UpdateHealth(_currentHealth);
        }
        else
        {
            Debug.Log("dead");
        }
    }

    public void AddHealth(float heal)
    {
        if (_currentHealth <= _maxHealth)
        {
            _currentHealth = _currentHealth + heal;
            hud.GetComponent<CanvasManager>().UpdateHealth(_currentHealth);
        }
        else
        {
            Debug.Log("Health Full");
        }
        // for (int i = 0; i < heal; i++)
        // {
        //     if (_currentHealth <= _maxHealth)
        //     {
        //         _currentHealth = _currentHealth + 1;

        //     }
        //     else
        //     {
        //         Debug.Log("health full");
        //     }
        // }
    }

    internal void AddAmmo()
    {
        currentAmmo = currentAmmo + 10;
        hud.GetComponent<CanvasManager>().UpdateAmmo(currentAmmo);
    }
}
