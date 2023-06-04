using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class in_game_menu : MonoBehaviour
{
    [SerializeField] GameObject Pause_Canvas;

    void Start(){
        Pause_Canvas.SetActive(false);
    }

    public void Update(){
        if(Input.GetKey(KeyCode.Escape))
        {
            EnableSettingUI();
        }
    }

    void EnableSettingUI(){
        Pause_Canvas.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
    }

    public void cancel(){
        Pause_Canvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
}
