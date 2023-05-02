using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text coinScore;

    int coin = 0;
    // Start is called before the first frame update

    void Awake() {
        instance = this;
    }

    void Start()
    {
        coinScore.text = coin.ToString() + "Coins";
    }

    public void AddPoint(){
        coin += 1;
        coinScore.text = coin.ToString() + "Coins";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
