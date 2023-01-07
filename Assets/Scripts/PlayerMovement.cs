using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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

    private void Awake()
    {
        instance = this;
    }

    void start(){

    }
    void Update()
    {       //Player Movement
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
                }
                else
                {
                    Debug.Log("Nothing");
                }
                currentAmmo--;
                gunAnim.SetTrigger("Shoot");
            }
        }

    }
}
