using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WarSceneResources : MonoBehaviour
{
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI goldText;
    private void Update()
    {
        woodText.text = PlayerPrefs.GetInt("WarSceneWoodCount").ToString();
        goldText.text = PlayerPrefs.GetInt("GoldCount").ToString();
    }
}
