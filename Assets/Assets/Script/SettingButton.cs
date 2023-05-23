using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    [SerializeField] GameObject SettingCanvas;

    public void openSetting(){
        SettingCanvas.SetActive(true);
    }

    public void closeSetting(){
        SettingCanvas.SetActive(false);
    }
}
