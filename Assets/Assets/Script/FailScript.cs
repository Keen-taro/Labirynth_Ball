using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailScript : MonoBehaviour
{
    public static FailScript instance;


    [SerializeField] GameObject failed_canvas;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        failed_canvas.SetActive(false);
    }

    public void forceFinish()
    {
        failed_canvas.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
    }
}
