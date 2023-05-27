using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOnPlay : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private bool isPaused;
    //private bool cooldown = false;
    //private float timer;
    //private float time;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if(isPaused)
        {
            Cursor.lockState = CursorLockMode.Confined;
            EnableSettingUI();
            
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            DisableSettingUI();
        }
    }

    void EnableSettingUI() {pauseMenuUI.SetActive(true);}

    void DisableSettingUI() {pauseMenuUI.SetActive(false);}

    /*
    void Cooldown() 
    {
        while (timer != 0f)
        {
            cooldown = true;
            timer -= Time.deltaTime;
        }
    }
    */

}
