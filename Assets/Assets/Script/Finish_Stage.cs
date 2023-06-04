using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_Stage : MonoBehaviour
{
    public static Finish_Stage instance;

    [SerializeField] GameObject finish_canvas;
    [SerializeField] int maxCoin;

    int coin = 0;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        finish_canvas.SetActive(false);
    }

    // Update is called once per frame
    public void addPointToFinish(){
        coin += 1;

        if(coin == maxCoin){
            finish_canvas.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined; 
            Time.timeScale = 0;
        }
    }
}
