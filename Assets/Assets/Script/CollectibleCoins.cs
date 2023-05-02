using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCoins : MonoBehaviour
{
    public int coins;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Coin")
        {
            Debug.Log("Coin Collected");
            ScoreManager.instance.AddPoint();
            //coins = coins + 1;
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
