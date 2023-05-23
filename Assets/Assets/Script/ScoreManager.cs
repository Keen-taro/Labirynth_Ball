using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private TextMeshProUGUI coinScore = null;

    int coin = 0;
    // Start is called before the first frame update

    void Awake() {
        instance = this;
    }

    void Start()
    {
        coinScore.text = coin.ToString() + " COINS";
    }

    public void AddPoint(){
        coin += 1;
        coinScore.text = coin.ToString() + " COINS";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
