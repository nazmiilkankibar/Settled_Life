using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BuildingCreater : MonoBehaviour
{
    public GameObject building;
    public int price;
    public TextMeshPro priceText;
    IEnumerator spend;
    GameManager gm;

    //deneme
    private float test;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        spend = SpendMoney();
        test = price;
    }
    private void Update()
    {
        priceText.text = price.ToString();
        if (price <= 0)
        {
            building.SetActive(true);
            GameManagerBuildingNamesUpdate();
            transform.gameObject.SetActive(false);
        }
        SetActiveObjects();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(spend);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(spend);
        }
    }
    void SetActiveObjects()
    {
        switch (price / test)
        {
            case .9f:
                if (building.name == "Main House")
                {
                    building.SetActive(true);
                    building.transform.GetChild(0).gameObject.SetActive(true);
                    building.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    building.SetActive(true);
                    building.transform.GetChild(0).gameObject.SetActive(true);
                }
                break;
            case .8f:
                if (building.name == "Main House")
                {
                    building.SetActive(true);
                    building.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    building.transform.GetChild(1).gameObject.SetActive(true);
                }
                break;
            case .6f:
                if (building.name == "Main House")
                {
                    building.SetActive(true);
                    building.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                }
                else
                {
                    building.transform.GetChild(2).gameObject.SetActive(true);
                }
                break;
            case .4f:
                if (building.name == "Main House")
                {
                    building.SetActive(true);
                    building.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
                }
                else
                {
                    building.transform.GetChild(3).gameObject.SetActive(true);
                }
                break;
            case .2f:
                if (building.name == "Main House")
                {
                    building.SetActive(true);
                    building.transform.GetChild(0).GetChild(4).gameObject.SetActive(true);
                }
                else
                {
                    building.transform.GetChild(4).gameObject.SetActive(true);
                }
                break;
            case 0f:
                if (building.name == "Main House")
                {
                    building.SetActive(true);
                    building.transform.GetChild(0).GetChild(5).gameObject.SetActive(true);
                    building.transform.GetChild(3).gameObject.SetActive(true);
                    building.GetComponent<BoxCollider>().enabled = true;
                }
                else
                {
                    building.GetComponent<BoxCollider>().enabled = true;
                    building.transform.GetChild(5).gameObject.SetActive(true);
                    building.transform.GetChild(6).gameObject.SetActive(true);
                    building.transform.GetChild(7).gameObject.SetActive(true);
                    building.transform.GetChild(8).gameObject.SetActive(true);
                    building.transform.GetChild(9).gameObject.SetActive(true);
                    building.transform.GetChild(10).gameObject.SetActive(true);
                    building.transform.GetChild(11).gameObject.SetActive(true);
                    building.transform.GetChild(12).gameObject.SetActive(true);
                }
                break;
            default:
                break;
        }
    }
    IEnumerator SpendMoney()
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
    private void GameManagerBuildingNamesUpdate()
    {
        switch (building.name)
        {
            case "Main House":
                PlayerPrefs.SetInt("MainHouse", 1);
                PlayerPrefs.SetInt("MainHouseLevel", 1);
                gm.OpenedBuildingCreaters();
                gm.OpenedTowerCreaters();
                break;
            case "Wood Mill":
                PlayerPrefs.SetInt("WoodMill", 1);
                break;
            case "Wood Buyer":
                PlayerPrefs.SetInt("WoodBuyer", 1);
                break;
            case "Blacksmith":
                PlayerPrefs.SetInt("Blacksmith", 1);
                break;
            case "Player Upgrader":
                PlayerPrefs.SetInt("PlayerUpgrader", 1);
                break;
            case "Soldier Upgrader":
                PlayerPrefs.SetInt("SoldierUpgrader", 1);
                break;
            case "Tower Upgrader":
                PlayerPrefs.SetInt("TowerUpgrader", 1);
                break;
            case "Hospital":
                PlayerPrefs.SetInt("Hospital", 1);
                break;
            default:
                break;
        }
    }
}
