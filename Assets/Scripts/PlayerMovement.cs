using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDamagable
{
    #region playerAttribs
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maxHealth = 100f;
    [SerializeField]
    private AudioSource shootSoundEffect;

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
    public GameObject[] enemmies;
    public CameraControl cameraControl;
    #endregion






    public static PlayerMovement instance;

    private void Awake()
    {
        instance = this;
        isDead = false;
        enemmies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void start(){
        _currentHealth = _maxHealth;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void Move()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 moveHorizontal = transform.up * -moveInput.x;
        Vector3 moveVertical = transform.right * moveInput.y;
        if (moveInput.x == 1)
        {
            Debug.Log("X " + moveInput.x);
            cameraControl.TiltRight();
        }
        else if (moveInput.x == -1)
        {
            cameraControl.TiltLeft();
        }
        theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;
        //Camera Movement 
        moveInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - moveInput.x);
    //    viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, moveInput.y, 0f));
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo > 0)
            {
                shootSoundEffect.Play();
                Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("Shooting at" + hit.transform.name);
                    Instantiate(bulletImpact, hit.point, transform.rotation);
                    if (hit.transform.CompareTag("Enemy") && GameState.isStandard)
                    {
                        hit.transform.parent.GetComponent<IDamagable>().TakeDamage(30);

                    }
                    else if(hit.transform.CompareTag("Enemy"))
                    {
                        hit.transform.parent.GetComponent<IDamagable>().Heal(-15);
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
    }

    void Update()
    {

        //if (theRB.velocity.magnitude==0)
        //{
        //    camAnim.SetBool("IsWalking", false);
        //}
        //else
        //{
        //    camAnim.SetBool("IsWalking", true);
        //}


        if (!PauseMenu.Paused && !isDead)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //Player Movement
            Move();

            //Shooting
            Shoot();
            

            if (_currentHealth <= 0)
            {
                isDead = true;  
            }

            if (enemmies.Length <= 0)
            {

                theRB.velocity = Vector3.zero;
                deathMenu.GetComponent<DeathMenu>().toggleDeathMenu();
            }
        }
        else if (isDead)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            theRB.velocity = Vector3.zero;
            deathMenu.GetComponent<DeathMenu>().toggleDeathMenu(); 
        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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
            _currentHealth = (_currentHealth + heal) % _maxHealth;
            hud.GetComponent<CanvasManager>().UpdateHealth(_currentHealth);
        }
        else
        {
            Debug.Log("Health Full");
        }
    }

    public void Heal(float damage)
    {
        throw new NotImplementedException();
    }

    internal void AddAmmo()
    {
        currentAmmo = currentAmmo + 10;
        hud.GetComponent<CanvasManager>().UpdateAmmo(currentAmmo);
    }
}
