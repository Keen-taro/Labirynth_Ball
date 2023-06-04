using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCoins : MonoBehaviour
{
    //public int coins;

    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Coin")
        {
            Debug.Log("Coin Collected");
            ScoreManager.instance.AddPoint();
            Finish_Stage.instance.addPointToFinish();
            //coins = coins + 1;
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }
}
