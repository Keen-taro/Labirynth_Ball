using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sensitivity_Slider : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sliderText = null;
    [SerializeField] private float maxMouseSensitivity = 100f;

    public float localValue = 10f;

    public void SliderChange(float value)
    {
        localValue = value * maxMouseSensitivity * 0.01f;
        sliderText.text = localValue.ToString("0");
    }

    public float getLocalValue(){
        return localValue;
    }
}
