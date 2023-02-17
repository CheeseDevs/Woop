using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float tiltSpeed = 50.0f; // Adjust the speed of the tilt
    [SerializeField]
    private Quaternion _startRot;
    [SerializeField]private Quaternion _LeftRot;
    [SerializeField]private Quaternion _RightRot;
    [SerializeField]
    private float speed = 10;
    private bool _isRotating = false;

    private void Start()
    {
        _startRot = transform.rotation;
    }



    public void TiltLeft() {
        Debug.Log("P: " + transform.eulerAngles.z);
        if (transform.rotation.eulerAngles.z <= 275)
        {
            transform.Rotate(0, 0, tiltSpeed * Time.deltaTime, Space.Self);
            _isRotating = true;
        }
        //Debug.Log("log");
        _isRotating = false;

    }
    public void TiltRight()
    {
        if (transform.rotation.eulerAngles.z >= 265)
        {
            transform.Rotate(0, 0, -tiltSpeed * Time.deltaTime, Space.Self);
            _isRotating = true;
        }
        _isRotating = false;


    }
    public void TiltBackToNormal()
    {

        Quaternion rot = Quaternion.Euler(0, transform.rotation.eulerAngles.y, _startRot.eulerAngles.z);
        transform.localRotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime*speed);
    }
    private void Update()
    {
        
        //TiltBackToNormal();


    }


}
