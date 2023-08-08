using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TowerCreater : MonoBehaviour
{
    public GameObject building;
    public int price;
    public TextMeshPro priceText;
    IEnumerator inVillageSpend;
    IEnumerator inWarSceneSpend;
    GameManager gm;

    //deneme
    private float test;
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
        inVillageSpend = SpendMoneyInVillage();
        inWarSceneSpend = SpendMoneyInWarScene();
        test = price;
    }
    private void Update()
    {
        priceText.text = price.ToString();
        if (price <= 0)
        {
            building.SetActive(true);
            transform.gameObject.SetActive(false);
            GameManagerOpenedTowers();
        }
        SetActiveObjects();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (other.CompareTag("Player") && PlayerPrefs.GetInt("WoodCount") > 0)
            {
                StartCoroutine(inVillageSpend);
            }
            else
            {
                StopCoroutine(inVillageSpend);
            }
        }
        else
        {
            if (other.CompareTag("Player") && PlayerPrefs.GetInt("WoodCount") > 0)
            {
                StartCoroutine(inWarSceneSpend);
            }
            else
            {
                StopCoroutine(inWarSceneSpend);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(inVillageSpend);
            StopCoroutine(inWarSceneSpend);
        }
    }
    void SetActiveObjects()
    {
        switch (price / test)
        {
            case .9f:
                building.SetActive(true);
                building.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case .8f:
                building.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case .6f:
                building.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case .4f:
                building.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case .2f:
                building.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case 0f:
                building.transform.GetChild(5).gameObject.SetActive(true);
                building.transform.GetChild(6).gameObject.SetActive(true);
                building.transform.GetChild(7).gameObject.SetActive(true);
                building.transform.GetChild(8).gameObject.SetActive(true);
                if (SceneManager.GetActiveScene().buildIndex != 0)
                {
                    building.transform.GetChild(9).gameObject.SetActive(true);
                    building.transform.tag = "Tower";
                }
                break;
            default:
                break;
        }
    }
    IEnumerator SpendMoneyInVillage()
    {
        while (true)
        {
            if (PlayerPrefs.GetInt("WoodCount") > 0)
            {
                PlayerPrefs.SetInt("WoodCount", PlayerPrefs.GetInt("WoodCount") - 1);
                price--;
            }
            yield return new WaitForSeconds(.05f);
        }
    }
    IEnumerator SpendMoneyInWarScene()
    {
        while (true)
        {
            if (PlayerPrefs.GetInt("WarSceneWoodCount") > 0)
            {
                PlayerPrefs.SetInt("WarSceneWoodCount", PlayerPrefs.GetInt("WarSceneWoodCount") - 1);
                price--;
            }
            yield return new WaitForSeconds(.05f);
        }
    }
    private void GameManagerOpenedTowers()
    {
        switch (building.name)
        {
            case "Archer Tower 1":
                PlayerPrefs.SetInt("Archer Tower 1", 1);
                break;
            case "Archer Tower 2":
                PlayerPrefs.SetInt("Archer Tower 2", 1);
                break;
            case "Archer Tower 3":
                PlayerPrefs.SetInt("Archer Tower 3", 1);
                break;
            case "Archer Tower 4":
                PlayerPrefs.SetInt("Archer Tower 4", 1);
                break;
            case "Archer Tower 5":
                PlayerPrefs.SetInt("Archer Tower 5", 1);
                break;
            case "Archer Tower 6":
                PlayerPrefs.SetInt("Archer Tower 6", 1);
                break;
            default:
                break;
        }
    }
}
