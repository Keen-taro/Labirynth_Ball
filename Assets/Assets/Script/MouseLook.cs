using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MouseLook : MonoBehaviour
{
    /*
    [SerializeField] private TextMeshProUGUI sliderText = null;
    [SerializeField] private float maxMouseSensitivity = 100f;
    */
    //private float sens;
    //private float localValue = 10f;

    public Transform playerBody;
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    
    /*
    public void SliderChange(float value)
    {
        localValue = value * maxMouseSensitivity * 0.01f;
        sliderText.text = localValue.ToString("0");
        sens = localValue;
    }
    */

    void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    void Update(){
        float rotationX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float rotationY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        xRotation -= rotationY;
        xRotation = Mathf.Clamp(xRotation, -90f , 15f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f , 0f);
        playerBody.Rotate(Vector3.up * rotationX);
    }
}