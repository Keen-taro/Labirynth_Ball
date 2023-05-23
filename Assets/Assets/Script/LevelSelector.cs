using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{

    private string level;

    public void easyLevel()
    {
        level = "easy_Level";
    }
    public void normalLevel()
    {
        level = "normal_Level";
    }
    public void hardLevel()
    {
        level = "hard_Level";
    }

    public string getLevel()
    {
        return level;
    }
}