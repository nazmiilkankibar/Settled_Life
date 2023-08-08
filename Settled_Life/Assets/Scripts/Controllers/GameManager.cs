using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public List<GameObject> buildings = new List<GameObject>();
    public List<GameObject> buildingCreaters = new List<GameObject>();
    public List<GameObject> towerCreaters = new List<GameObject>();
    public List<GameObject> towers = new List<GameObject>();
    public List<GameObject> walls = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> soldiers = new List<GameObject>();
    private void Awake()
    {
        Application.targetFrameRate = 120;
        OpenedBuildingCreaters();
        OpenedBuildings();
        OpenedTowerCreaters();
        OpenedTowers();
        OpenedWalls();
        OpenedSoldiers();
        PlayerPrefs.SetInt("WarSceneWoodCount", 0);
    }
    public void OpenedBuildings()
    {
        if (PlayerPrefs.GetInt("MainHouse") != 0)
        {
            switch (PlayerPrefs.GetInt("MainHouseLevel"))
            {
                case 1:
                    //Birinci bina
                    buildingCreaters[0].SetActive(false);
                    buildings[0].SetActive(true);
                    buildings[0].transform.GetChild(0).gameObject.SetActive(true);
                    buildings[0].transform.GetChild(3).gameObject.SetActive(true);
                    for (int i = 0; i < buildings[0].transform.GetChild(0).childCount; i++)
                    {
                        buildings[0].transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
                    }
                    buildings[0].transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;

                    break;
                case 2:
                    //Birinci bina
                    buildingCreaters[0].SetActive(false);
                    buildings[0].SetActive(true);
                    buildings[0].transform.GetChild(0).gameObject.SetActive(true);
                    buildings[0].transform.GetChild(3).gameObject.SetActive(true);
                    for (int i = 0; i < buildings[0].transform.GetChild(0).childCount; i++)
                    {
                        buildings[0].transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
                    }
                    buildings[0].transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
                    //Ýkinci bina
                    buildingCreaters[0].SetActive(false);
                    buildings[0].SetActive(true);
                    buildings[0].transform.GetChild(1).gameObject.SetActive(true);
                    for (int i = 0; i < buildings[0].transform.GetChild(1).childCount; i++)
                    {
                        buildings[0].transform.GetChild(1).GetChild(i).gameObject.SetActive(true);
                    }
                    buildings[0].transform.GetChild(1).GetComponent<BoxCollider>().enabled = true;
                    break;
                case 3:
                    //Birinci bina
                    buildingCreaters[0].SetActive(false);
                    buildings[0].SetActive(true);
                    buildings[0].transform.GetChild(0).gameObject.SetActive(true);
                    buildings[0].transform.GetChild(3).gameObject.SetActive(true);
                    for (int i = 0; i < buildings[0].transform.GetChild(0).childCount; i++)
                    {
                        buildings[0].transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
                    }
                    buildings[0].transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
                    //Ýkinci bina
                    buildingCreaters[0].SetActive(false);
                    buildings[0].SetActive(true);
                    buildings[0].transform.GetChild(1).gameObject.SetActive(true);
                    for (int i = 0; i < buildings[0].transform.GetChild(1).childCount; i++)
                    {
                        buildings[0].transform.GetChild(1).GetChild(i).gameObject.SetActive(true);
                    }
                    buildings[0].transform.GetChild(1).GetComponent<BoxCollider>().enabled = true;
                    //Üçüncü Bina
                    buildingCreaters[0].SetActive(false);
                    buildings[0].SetActive(true);
                    buildings[0].transform.GetChild(2).gameObject.SetActive(true);
                    for (int i = 0; i < buildings[0].transform.GetChild(2).childCount; i++)
                    {
                        buildings[0].transform.GetChild(2).GetChild(i).gameObject.SetActive(true);
                    }
                    buildings[0].transform.GetChild(2).GetComponent<BoxCollider>().enabled = true;
                    break;
                default:
                    //Birinci bina
                    buildingCreaters[0].SetActive(false);
                    buildings[0].SetActive(true);
                    buildings[0].transform.GetChild(0).gameObject.SetActive(true);
                    buildings[0].transform.GetChild(3).gameObject.SetActive(true);
                    for (int i = 0; i < buildings[0].transform.GetChild(0).childCount; i++)
                    {
                        buildings[0].transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
                    }
                    buildings[0].transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
                    //Ýkinci bina
                    buildingCreaters[0].SetActive(false);
                    buildings[0].SetActive(true);
                    buildings[0].transform.GetChild(1).gameObject.SetActive(true);
                    for (int i = 0; i < buildings[0].transform.GetChild(1).childCount; i++)
                    {
                        buildings[0].transform.GetChild(1).GetChild(i).gameObject.SetActive(true);
                    }
                    buildings[0].transform.GetChild(1).GetComponent<BoxCollider>().enabled = true;
                    //Üçüncü Bina
                    buildingCreaters[0].SetActive(false);
                    buildings[0].SetActive(true);
                    buildings[0].transform.GetChild(2).gameObject.SetActive(true);
                    for (int i = 0; i < buildings[0].transform.GetChild(2).childCount; i++)
                    {
                        buildings[0].transform.GetChild(2).GetChild(i).gameObject.SetActive(true);
                    }
                    buildings[0].transform.GetChild(2).GetComponent<BoxCollider>().enabled = true;
                    break;
            }
        }
        if (PlayerPrefs.GetInt("WoodMill") != 0)
        {
            buildingCreaters[1].SetActive(false);
            buildings[1].SetActive(true);
            for (int i = 0; i < buildings[1].transform.childCount; i++)
            {
                buildings[1].transform.GetChild(i).gameObject.SetActive(true);
            }
            buildings[1].GetComponent<BoxCollider>().enabled = true;
        }
        if (PlayerPrefs.GetInt("WoodBuyer") != 0)
        {
            buildingCreaters[2].SetActive(false);
            buildings[2].SetActive(true);
            for (int i = 0; i < buildings[2].transform.childCount; i++)
            {
                buildings[2].transform.GetChild(i).gameObject.SetActive(true);
            }
            buildings[2].GetComponent<BoxCollider>().enabled = true;
        }
        if (PlayerPrefs.GetInt("Blacksmith") != 0)
        {
            buildingCreaters[3].SetActive(false);
            buildings[3].SetActive(true);
            for (int i = 0; i < buildings[3].transform.childCount; i++)
            {
                buildings[3].transform.GetChild(i).gameObject.SetActive(true);
            }
            buildings[3].GetComponent<BoxCollider>().enabled = true;
        }
        if (PlayerPrefs.GetInt("PlayerUpgrader") != 0)
        {
            buildingCreaters[4].SetActive(false);
            buildings[4].SetActive(true);
            for (int i = 0; i < buildings[4].transform.childCount; i++)
            {
                buildings[4].transform.GetChild(i).gameObject.SetActive(true);
            }
            buildings[4].GetComponent<BoxCollider>().enabled = true;
        }
        if (PlayerPrefs.GetInt("SoldierUpgrader") != 0)
        {
            buildingCreaters[5].SetActive(false);
            buildings[5].SetActive(true);
            for (int i = 0; i < buildings[5].transform.childCount; i++)
            {
                buildings[5].transform.GetChild(i).gameObject.SetActive(true);
            }
            buildings[5].GetComponent<BoxCollider>().enabled = true;
        }
        if (PlayerPrefs.GetInt("TowerUpgrader") != 0)
        {
            buildingCreaters[6].SetActive(false);
            buildings[6].SetActive(true);
            for (int i = 0; i < buildings[6].transform.childCount; i++)
            {
                buildings[6].transform.GetChild(i).gameObject.SetActive(true);
            }
            buildings[6].GetComponent<BoxCollider>().enabled = true;
        }
        if (PlayerPrefs.GetInt("Hospital") != 0)
        {
            buildingCreaters[7].SetActive(false);
            buildings[7].SetActive(true);
            for (int i = 0; i < buildings[7].transform.childCount; i++)
            {
                buildings[7].transform.GetChild(i).gameObject.SetActive(true);
            }
            buildings[7].GetComponent<BoxCollider>().enabled = true;
        }
    }
    public void OpenedBuildingCreaters()
    {
        switch (PlayerPrefs.GetInt("MainHouseLevel"))
        {
            case 0:
                buildingCreaters[0].SetActive(true);
                break;
            case 1:
                if (PlayerPrefs.GetInt("WoodMill") == 0)
                {
                    buildingCreaters[1].SetActive(true);
                }
                if (PlayerPrefs.GetInt("WoodBuyer") == 0)
                {
                    buildingCreaters[2].SetActive(true);
                }
                if (PlayerPrefs.GetInt("Hospital") == 0)
                {
                    buildingCreaters[7].SetActive(true);
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("WoodMill") == 0)
                {
                    buildingCreaters[1].SetActive(true);
                }
                if (PlayerPrefs.GetInt("WoodBuyer") == 0)
                {
                    buildingCreaters[2].SetActive(true);
                }
                if (PlayerPrefs.GetInt("Blacksmith") == 0)
                {
                    buildingCreaters[3].SetActive(true);
                }
                if (PlayerPrefs.GetInt("PlayerUpgrader") == 0)
                {
                    buildingCreaters[4].SetActive(true);
                }
                if (PlayerPrefs.GetInt("Hospital") == 0)
                {
                    buildingCreaters[7].SetActive(true);
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("WoodMill") == 0)
                {
                    buildingCreaters[1].SetActive(true);
                }
                if (PlayerPrefs.GetInt("WoodBuyer") == 0)
                {
                    buildingCreaters[2].SetActive(true);
                }
                if (PlayerPrefs.GetInt("Blacksmith") == 0)
                {
                    buildingCreaters[3].SetActive(true);
                }
                if (PlayerPrefs.GetInt("PlayerUpgrader") == 0)
                {
                    buildingCreaters[4].SetActive(true);
                }
                if (PlayerPrefs.GetInt("SoldierUpgrader") == 0)
                {
                    buildingCreaters[5].SetActive(true);
                }
                if (PlayerPrefs.GetInt("TowerUpgrader") == 0)
                {
                    buildingCreaters[6].SetActive(true);
                }
                if (PlayerPrefs.GetInt("Hospital") == 0)
                {
                    buildingCreaters[7].SetActive(true);
                }
                break;
            default:
                if (PlayerPrefs.GetInt("WoodMill") == 0)
                {
                    buildingCreaters[1].SetActive(true);
                }
                if (PlayerPrefs.GetInt("WoodBuyer") == 0)
                {
                    buildingCreaters[2].SetActive(true);
                }
                if (PlayerPrefs.GetInt("Blacksmith") == 0)
                {
                    buildingCreaters[3].SetActive(true);
                }
                if (PlayerPrefs.GetInt("PlayerUpgrader") == 0)
                {
                    buildingCreaters[4].SetActive(true);
                }
                if (PlayerPrefs.GetInt("SoldierUpgrader") == 0)
                {
                    buildingCreaters[5].SetActive(true);
                }
                if (PlayerPrefs.GetInt("TowerUpgrader") == 0)
                {
                    buildingCreaters[6].SetActive(true);
                }
                if (PlayerPrefs.GetInt("Hospital") == 0)
                {
                    buildingCreaters[7].SetActive(true);
                }
                break;
        }
    }
    public void OpenedTowers()
    {
        if (PlayerPrefs.GetInt("Archer Tower 1") == 1)
        {
            ActivateTower(0);
            towerCreaters[0].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Archer Tower 2") == 1)
        {
            ActivateTower(1);
            towerCreaters[1].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Archer Tower 3") == 1)
        {
            ActivateTower(2);
            towerCreaters[2].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Archer Tower 4") == 1)
        {
            ActivateTower(3);
            towerCreaters[3].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Archer Tower 5") == 1)
        {
            ActivateTower(4);
            towerCreaters[4].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Archer Tower 6") == 1)
        {
            ActivateTower(5);
            towerCreaters[5].SetActive(false);
        }
    }
    public void OpenedTowerCreaters()
    {
        switch (PlayerPrefs.GetInt("MainHouseLevel"))
        {
            case 1:
                if (PlayerPrefs.GetInt("Archer Tower 1") == 0)
                {
                    towerCreaters[0].SetActive(true);
                }
                if (PlayerPrefs.GetInt("Archer Tower 2") == 0)
                {
                    towerCreaters[1].SetActive(true);
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("Archer Tower 1") == 0)
                {
                    towerCreaters[0].SetActive(true);
                }
                if (PlayerPrefs.GetInt("Archer Tower 2") == 0)
                {
                    towerCreaters[1].SetActive(true);
                }
                if (PlayerPrefs.GetInt("Archer Tower 3") == 0)
                {
                    towerCreaters[2].SetActive(true);
                }
                if (PlayerPrefs.GetInt("Archer Tower 4") == 0)
                {
                    towerCreaters[3].SetActive(true);
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("Archer Tower 1") == 0)
                {
                    towerCreaters[0].SetActive(true);
                }
                if (PlayerPrefs.GetInt("Archer Tower 2") == 0)
                {
                    towerCreaters[1].SetActive(true);
                }
                if (PlayerPrefs.GetInt("Archer Tower 3") == 0)
                {
                    towerCreaters[2].SetActive(true);
                }
                if (PlayerPrefs.GetInt("Archer Tower 4") == 0)
                {
                    towerCreaters[3].SetActive(true);
                }
                //if (PlayerPrefs.GetInt("Archer Tower 5") == 0)
                //{
                //    towerCreaters[4].SetActive(true);
                //}
                //if (PlayerPrefs.GetInt("Archer Tower 6") == 0)
                //{
                //    towerCreaters[5].SetActive(true);
                //}
                break;
            default:
                break;
        }
    }
    private void ActivateTower(int value)
    {
        GameObject tower = towers[value].gameObject;
        tower.SetActive(true);
        for (int i = 0; i < tower.transform.childCount; i++)
        {
            tower.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void OpenedWalls()
    {
        switch (PlayerPrefs.GetInt("MainHouseLevel"))
        {
            case 2:
                walls[0].SetActive(true);
                walls[1].SetActive(false);
                break;
            case 4:
                walls[0].SetActive(false);
                walls[1].SetActive(true);
                break;
            default:
                break;
        }
    }
    public void OpenedSoldiers()
    {
        switch (PlayerPrefs.GetInt("MainHouse"))
        {
            case 2:
                soldiers[0].SetActive(true);
                soldiers[1].SetActive(true);
                break;
            case 3:
                soldiers[2].SetActive(true);
                soldiers[3].SetActive(true);
                break;
            default:
                break;
        }
    }
    public void ResetGame()
    {
        //Buildings
        PlayerPrefs.SetInt("MainHouse", 0);
        PlayerPrefs.SetInt("WoodMill", 0);
        PlayerPrefs.SetInt("WoodBuyer", 0);
        PlayerPrefs.SetInt("Blacksmith", 0);
        PlayerPrefs.SetInt("PlayerUpgrader", 0);
        PlayerPrefs.SetInt("SoldierUpgrader", 0);
        PlayerPrefs.SetInt("TowerUpgrader", 0);
        PlayerPrefs.SetInt("Hospital", 0);
        //Resources
        PlayerPrefs.SetInt("GoldCount", 0);
        PlayerPrefs.SetInt("WoodCount",0);
        PlayerPrefs.SetInt("WarSceneWoodCount", 0);
        //Wood Mill
        PlayerPrefs.SetInt("WoodMillProcessUpgrade", 0);
        PlayerPrefs.SetInt("WoodMillMaxStorageUpgrade", 0);
        PlayerPrefs.SetInt("CurrentWoodStorage", 0);
        //Blacksmith
        PlayerPrefs.SetInt("WeaponUpgrade", 0);
        PlayerPrefs.SetInt("ArmorUpgrade", 0);
        //Player Upgrade
        PlayerPrefs.SetFloat("PlayerHealth", 25);   //Standart deðer
        PlayerPrefs.SetFloat("PlayerSpeed", 5);     //Standart deðer
        PlayerPrefs.SetInt("PlayerHealthUpgrade", 0);
        PlayerPrefs.SetInt("PlayerSpeedUpgrade", 0);
        //Towers
        PlayerPrefs.SetInt("Archer Tower 1", 0);
        PlayerPrefs.SetInt("Archer Tower 2", 0);
        PlayerPrefs.SetInt("Archer Tower 3", 0);
        PlayerPrefs.SetInt("Archer Tower 4", 0);
        PlayerPrefs.SetInt("Archer Tower 5", 0);
        PlayerPrefs.SetInt("Archer Tower 6", 0);
        //Tower Upgrades
        PlayerPrefs.SetInt("TowerDamage", 0);
        PlayerPrefs.SetInt("TowerDurability", 0);
        //Soldier Upgrades
        PlayerPrefs.SetInt("SoldierAttackPoint", 10);
        PlayerPrefs.SetInt("SoldierHealthPoint", 50);


        PlayerPrefs.SetInt("MainHouseLevel", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void SpendGold(int value)
    {
        PlayerPrefs.SetInt("GoldCount", PlayerPrefs.GetInt("GoldCount") - value);
    }
}
