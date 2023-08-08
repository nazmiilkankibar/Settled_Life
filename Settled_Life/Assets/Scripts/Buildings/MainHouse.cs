using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MainHouse : MonoBehaviour
{
    public Animator mainHouseUIAnimator;
    public Animator mainHouseUIMaxLevelAnimator;

    public TextMeshProUGUI woodCostText;
    public TextMeshProUGUI goldCostText;

    public Button upgradeButton;

    private int woodCost;
    private int goldCost;

    private GameManager gm;
    private void Start()
    {
        woodCost = 500;
        goldCost = 200;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        woodCostText.text = woodCost.ToString();
        goldCostText.text = goldCost.ToString();
        PlayerPrefs.GetInt("WoodMill");
        if (PlayerPrefs.GetInt("MainHouseLevel") >= 4)
        {
            mainHouseUIAnimator.SetBool("isOpen", false);
        }
    }
    public void LevelUp()
    {
        switch (PlayerPrefs.GetInt("MainHouseLevel"))
        {
            case 1:
                if (PlayerPrefs.GetInt("WoodCount") >= woodCost && PlayerPrefs.GetInt("GoldCount") >= goldCost)
                {
                    PlayerPrefs.SetInt("WoodCount", PlayerPrefs.GetInt("WoodCount") - woodCost);
                    PlayerPrefs.SetInt("GoldCount", PlayerPrefs.GetInt("GoldCount") - goldCost);
                    PlayerPrefs.SetInt("MainHouseLevel", 2);
                    woodCost = 1250;
                    goldCost = 600;
                    gm.OpenedBuildingCreaters();
                    gm.OpenedTowerCreaters();
                    gm.OpenedWalls();
                    gm.OpenedBuildings();

                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("WoodCount") >= woodCost && PlayerPrefs.GetInt("GoldCount") >= goldCost)
                {
                    PlayerPrefs.SetInt("WoodCount", PlayerPrefs.GetInt("WoodCount") - woodCost);
                    PlayerPrefs.SetInt("GoldCount", PlayerPrefs.GetInt("GoldCount") - goldCost);
                    PlayerPrefs.SetInt("MainHouseLevel", 3);
                    gm.OpenedBuildingCreaters();
                    gm.OpenedTowerCreaters();
                    gm.OpenedBuildings();
                    woodCost = 4500;
                    goldCost = 2100;
                    gm.soldiers[0].SetActive(true);
                    gm.soldiers[1].SetActive(true);
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("WoodCount") >= woodCost && PlayerPrefs.GetInt("GoldCount") >= goldCost)
                {
                    PlayerPrefs.SetInt("WoodCount", PlayerPrefs.GetInt("WoodCount") - woodCost);
                    PlayerPrefs.SetInt("GoldCount", PlayerPrefs.GetInt("GoldCount") - goldCost);
                    PlayerPrefs.SetInt("MainHouseLevel", 4);
                    gm.OpenedBuildingCreaters();
                    gm.OpenedTowerCreaters();
                    gm.OpenedWalls();
                    gm.OpenedBuildings();
                    gm.soldiers[2].SetActive(true);
                    gm.soldiers[3].SetActive(true);
                }
                break;
            default:
                break;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("MainHouseLevel") >= 4)
            {
                mainHouseUIAnimator.SetBool("isOpen", false);
                mainHouseUIMaxLevelAnimator.SetBool("isOpen", true);
            }
            else
            {
                mainHouseUIAnimator.SetBool("isOpen", true);
            }
            Camera.main.GetComponent<CameraFollower>().inHouse = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mainHouseUIAnimator.SetBool("isOpen", false);
            mainHouseUIMaxLevelAnimator.SetBool("isOpen", false);
            Camera.main.GetComponent<CameraFollower>().inHouse = false;
        }
    }
}
