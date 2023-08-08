using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResourcesManager : MonoBehaviour
{

    //Text Objects
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI goldText;
    private void Update()
    {
        woodText.text = PlayerPrefs.GetInt("WoodCount").ToString();
        goldText.text = PlayerPrefs.GetInt("GoldCount").ToString();
    }
}
