using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("GoldCount", PlayerPrefs.GetInt("GoldCount") + 1);
            Destroy(this.gameObject);
        }
    }
}
