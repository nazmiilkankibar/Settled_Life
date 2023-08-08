using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TestScript : MonoBehaviour
{
    public void ChangeScene()
    {
        PlayerPrefs.SetInt("WarSceneWoodCount", 0);
        SceneManager.LoadScene(0);
    }
}
