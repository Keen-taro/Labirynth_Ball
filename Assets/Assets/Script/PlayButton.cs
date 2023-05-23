using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] GameObject easy_btn;
    [SerializeField] GameObject norm_btn;
    [SerializeField] GameObject hard_btn;
    // Start is called before the first frame update
    public void activeButton()
    {
        if (easy_btn.activeInHierarchy == true &&
            norm_btn.activeInHierarchy == true &&
            hard_btn.activeInHierarchy == true)
        {
            easy_btn.SetActive(false);
            norm_btn.SetActive(false);
            hard_btn.SetActive(false);
        }else
        {
            easy_btn.SetActive(true);
            norm_btn.SetActive(true);
            hard_btn.SetActive(true);
        }
    }
}
