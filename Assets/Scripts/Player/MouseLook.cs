using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 1.5f;
    public float smoothing = 10f;

    private float _xMousePos;
    private float _smoothing;
    private float _currentLookPosition;

    public Transform playerBody;


    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ModifyInput();
        Move();
    }

    private void Move()
    {
        _currentLookPosition += _smoothing;
        transform.rotation = Quaternion.AngleAxis(_currentLookPosition, transform.up);
    }

    private void ModifyInput()
    {
        _xMousePos *= mouseSensitivity * smoothing;
        _smoothing = Mathf.Lerp(_smoothing, _xMousePos, 1f/smoothing);
    }

    private void GetInput()
    {
        _xMousePos = Input.GetAxisRaw("Mouse X");
    }
}
