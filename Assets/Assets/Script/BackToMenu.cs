using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] GameObject ExitToMenuButton;

    public void onClick(string menuScene)
    {
        SceneManager.LoadScene(menuScene);
    }
}
