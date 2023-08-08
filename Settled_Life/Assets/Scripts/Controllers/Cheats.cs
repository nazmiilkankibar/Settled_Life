using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    public void WoodCheat()
    {
        PlayerPrefs.SetInt("WoodCount", PlayerPrefs.GetInt("WoodCount") + 10000);
    }
    public void GoldCheat()
    {
        PlayerPrefs.SetInt("GoldCount", PlayerPrefs.GetInt("GoldCount") + 10000);
    }
}
