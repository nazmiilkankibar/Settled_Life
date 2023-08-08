using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Blacksmith : MonoBehaviour
{
    public Animator blacksmithUIAnimator;
    public WeaponAndArmor weaponAndArmor;

    //Weapon upgrade variables
    [Header("Weapon Upgrade Variables")]
    public int weaponUpgradeWoodCost;
    public int weaponUpgradeGoldCos;

    public TextMeshProUGUI weaponUpgradeWoodCostText;
    public TextMeshProUGUI weaponUpgradeGoldCostText;
    public Button weaponUpgradeButton;

    //Armor upgrade variables
    [Header("Armor Upgrade Variables")]
    public int armorUpgradeWoodCost;
    public int armorUpgradeGoldCost;

    public TextMeshProUGUI armorUpgradeWoodCostText;
    public TextMeshProUGUI armorUpgradeGoldCostText;
    public Button armorUpgradeButton;
    private void Start()
    {
        CalculateWeaponUpgradeCost();
        CalculateArmorUpgradeCost();
    }

    public void UpgradeWeapon()
    {
        if (PlayerPrefs.GetInt("WoodCount") >= weaponUpgradeWoodCost && PlayerPrefs.GetInt("GoldCount") >= weaponUpgradeGoldCos && PlayerPrefs.GetInt("WeaponUpgrade") < 11)
        {
            PlayerPrefs.SetInt("WeaponUpgrade", PlayerPrefs.GetInt("WeaponUpgrade") + 1);
            PlayerPrefs.SetInt("WoodCount", PlayerPrefs.GetInt("WoodCount") - weaponUpgradeWoodCost);
            PlayerPrefs.SetInt("GoldCount", PlayerPrefs.GetInt("GoldCount") - weaponUpgradeGoldCos);
            CalculateWeaponUpgradeCost();
            weaponAndArmor.ChangeWeapon(PlayerPrefs.GetInt("WeaponUpgrade"));
            print(PlayerPrefs.GetInt("WeaponUpgrade"));
            if (PlayerPrefs.GetInt("WeaponUpgrade") >= 10)
            {
                weaponUpgradeButton.interactable = false;
                weaponUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "Max level!!!";
            }
        }
    }
    public void UpgradeArmor()
    {
        if (PlayerPrefs.GetInt("WoodCount") >= armorUpgradeWoodCost && PlayerPrefs.GetInt("GoldCount") >= armorUpgradeGoldCost && PlayerPrefs.GetInt("ArmorUpgrade") < 10)
        {
            PlayerPrefs.SetInt("ArmorUpgrade", PlayerPrefs.GetInt("ArmorUpgrade") + 1);
            PlayerPrefs.SetInt("WoodCount", PlayerPrefs.GetInt("WoodCount") - armorUpgradeWoodCost);
            PlayerPrefs.SetInt("GoldCount", PlayerPrefs.GetInt("GoldCount") - armorUpgradeGoldCost);
            CalculateArmorUpgradeCost();
            weaponAndArmor.ChangeArmor(PlayerPrefs.GetInt("ArmorUpgrade"));
            print(PlayerPrefs.GetInt("ArmorUpgrade"));
            if (PlayerPrefs.GetInt("ArmorUpgrade") >= 10)
            {
                armorUpgradeButton.interactable = false;
                armorUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "Max level!!!";
            }
        }
    }
    private void CalculateWeaponUpgradeCost()
    {
        switch (PlayerPrefs.GetInt("WeaponUpgrade"))
        {
            case 0:
                weaponUpgradeGoldCos = 5;
                weaponUpgradeWoodCost = 25;
                weaponUpgradeWoodCostText.text = weaponUpgradeWoodCost.ToString();
                weaponUpgradeGoldCostText.text = weaponUpgradeGoldCos.ToString();
                break;
            case 1:
                weaponUpgradeGoldCos = 10;
                weaponUpgradeWoodCost = 50;
                weaponUpgradeWoodCostText.text = weaponUpgradeWoodCost.ToString();
                weaponUpgradeGoldCostText.text = weaponUpgradeGoldCos.ToString();
                break;
            case 2:
                weaponUpgradeGoldCos = 20;
                weaponUpgradeWoodCost = 100;
                weaponUpgradeWoodCostText.text = weaponUpgradeWoodCost.ToString();
                weaponUpgradeGoldCostText.text = weaponUpgradeGoldCos.ToString();
                break;
            case 3:
                weaponUpgradeGoldCos = 40;
                weaponUpgradeWoodCost = 200;
                weaponUpgradeWoodCostText.text = weaponUpgradeWoodCost.ToString();
                weaponUpgradeGoldCostText.text = weaponUpgradeGoldCos.ToString();
                break;
            case 4:
                weaponUpgradeGoldCos = 80;
                weaponUpgradeWoodCost = 400;
                weaponUpgradeWoodCostText.text = weaponUpgradeWoodCost.ToString();
                weaponUpgradeGoldCostText.text = weaponUpgradeGoldCos.ToString();
                break;
            case 5:
                weaponUpgradeGoldCos = 160;
                weaponUpgradeWoodCost = 800;
                weaponUpgradeWoodCostText.text = weaponUpgradeWoodCost.ToString();
                weaponUpgradeGoldCostText.text = weaponUpgradeGoldCos.ToString();
                break;
            case 6:
                weaponUpgradeGoldCos = 320;
                weaponUpgradeWoodCost = 1600;
                weaponUpgradeWoodCostText.text = weaponUpgradeWoodCost.ToString();
                weaponUpgradeGoldCostText.text = weaponUpgradeGoldCos.ToString();
                break;
            case 7:
                weaponUpgradeGoldCos = 640;
                weaponUpgradeWoodCost = 3200;
                weaponUpgradeWoodCostText.text = weaponUpgradeWoodCost.ToString();
                weaponUpgradeGoldCostText.text = weaponUpgradeGoldCos.ToString();
                break;
            case 8:
                weaponUpgradeGoldCos = 1280;
                weaponUpgradeWoodCost = 6400;
                weaponUpgradeWoodCostText.text = weaponUpgradeWoodCost.ToString();
                weaponUpgradeGoldCostText.text = weaponUpgradeGoldCos.ToString();
                break;
            case 9:
                weaponUpgradeWoodCostText.text = "-";
                weaponUpgradeGoldCostText.text = "-";
                weaponUpgradeButton.interactable = false;
                weaponUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "Max Level!!!";
                break;
            default:
                break;
        }
    }
    private void CalculateArmorUpgradeCost()
    {
        switch (PlayerPrefs.GetInt("ArmorUpgrade"))
        {
            case 0:
                armorUpgradeGoldCost = 5;
                armorUpgradeWoodCost = 25;
                armorUpgradeWoodCostText.text = armorUpgradeWoodCost.ToString();
                armorUpgradeGoldCostText.text = armorUpgradeGoldCost.ToString();
                break;
            case 1:
                armorUpgradeGoldCost = 10;
                armorUpgradeWoodCost = 50;
                armorUpgradeWoodCostText.text = armorUpgradeWoodCost.ToString();
                armorUpgradeGoldCostText.text = armorUpgradeGoldCost.ToString();
                break;
            case 2:
                armorUpgradeGoldCost = 20;
                armorUpgradeWoodCost = 100;
                armorUpgradeWoodCostText.text = armorUpgradeWoodCost.ToString();
                armorUpgradeGoldCostText.text = armorUpgradeGoldCost.ToString();
                break;
            case 3:
                armorUpgradeGoldCost = 40;
                armorUpgradeWoodCost = 200;
                armorUpgradeWoodCostText.text = armorUpgradeWoodCost.ToString();
                armorUpgradeGoldCostText.text = armorUpgradeGoldCost.ToString();
                break;
            case 4:
                armorUpgradeGoldCost = 80;
                armorUpgradeWoodCost = 400;
                armorUpgradeWoodCostText.text = armorUpgradeWoodCost.ToString();
                armorUpgradeGoldCostText.text = armorUpgradeGoldCost.ToString();
                break;
            case 5:
                armorUpgradeGoldCost = 160;
                armorUpgradeWoodCost = 800;
                armorUpgradeWoodCostText.text = armorUpgradeWoodCost.ToString();
                armorUpgradeGoldCostText.text = armorUpgradeGoldCost.ToString();
                break;
            case 6:
                armorUpgradeGoldCost = 320;
                armorUpgradeWoodCost = 1600;
                armorUpgradeWoodCostText.text = armorUpgradeWoodCost.ToString();
                armorUpgradeGoldCostText.text = armorUpgradeGoldCost.ToString();
                break;
            case 7:
                armorUpgradeGoldCost = 640;
                armorUpgradeWoodCost = 3200;
                armorUpgradeWoodCostText.text = armorUpgradeWoodCost.ToString();
                armorUpgradeGoldCostText.text = armorUpgradeGoldCost.ToString();
                break;
            case 8:
                armorUpgradeGoldCost = 1280;
                armorUpgradeWoodCost = 6400;
                armorUpgradeWoodCostText.text = armorUpgradeWoodCost.ToString();
                armorUpgradeGoldCostText.text = armorUpgradeGoldCost.ToString();
                break;
            case 9:
                armorUpgradeWoodCostText.text = "-";
                armorUpgradeGoldCostText.text = "-";
                armorUpgradeButton.interactable = false;
                armorUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "Max Level!!!";
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("WeaponUpgrade") >= 9)
            {
                weaponUpgradeButton.interactable = false;
                weaponUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "Max level!!!";
                weaponUpgradeWoodCostText.text = "-";
                weaponUpgradeGoldCostText.text = "-";
            }
            if (PlayerPrefs.GetInt("ArmorUpgrade") >= 9)
            {
                armorUpgradeButton.interactable = false;
                armorUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "Max level!!!";
                armorUpgradeWoodCostText.text = "-";
                armorUpgradeGoldCostText.text = "-";
            }
            blacksmithUIAnimator.SetBool("isOpen", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            blacksmithUIAnimator.SetBool("isOpen", false);
        }
    }
}
