using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{
    public Sensitivity_Slider maxMouseSensitivity;
    public Transform playerBody;
    public float mouseSensitivity;
    float xRotation = 0f;

    void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    void Update(){
        mouseSensitivity = maxMouseSensitivity.getLocalValue();
        
        float rotationX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float rotationY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        xRotation -= rotationY;
        xRotation = Mathf.Clamp(xRotation, -90f , 15f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f , 0f);
        playerBody.Rotate(Vector3.up * rotationX);
    }
}