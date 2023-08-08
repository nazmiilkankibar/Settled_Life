using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TowerUpgrader : MonoBehaviour
{
    public Animator towerUpgraderUIAnimator;

    public int damageUpgradeGoldCost;
    public int durabilityUpgradeGoldCost;

    public TextMeshProUGUI damageUpgradeGoldText;
    public Button damageUpgradeButton;

    public TextMeshProUGUI durabilityUpgradeGoldText;
    public Button durabilityUpgradeButton;

    public List<ArcherTower> towers = new List<ArcherTower>();
    private void Start()
    {
        CalculateUpgradeGoldCost();
        CalculateDurabilityGoldCost();
    }
    public void UpgradeDamage()
    {
        if (PlayerPrefs.GetInt("GoldCount") >= damageUpgradeGoldCost)
        {
            PlayerPrefs.SetInt("TowerDamage", PlayerPrefs.GetInt("TowerDamage") + 1);
            GameManager.SpendGold(damageUpgradeGoldCost);
            for (int i = 0; i < towers.Count; i++)
            {
                towers[i].CalculateDamage();
            }
            CalculateUpgradeGoldCost();
        }
    }
    public void UpgradeDurability()
    {
        if (PlayerPrefs.GetInt("GoldCount") >= durabilityUpgradeGoldCost)
        {
            PlayerPrefs.SetInt("TowerDurability", PlayerPrefs.GetInt("TowerDurability") + 1);
            GameManager.SpendGold(durabilityUpgradeGoldCost);
            for (int i = 0; i < towers.Count; i++)
            {
                towers[i].CalculateDurability();
            }
            CalculateDurabilityGoldCost();
        }
    }
    private void CalculateUpgradeGoldCost()
    {
        switch (PlayerPrefs.GetInt("TowerDamage"))
        {
            case 0:
                damageUpgradeGoldCost = 10;
                damageUpgradeGoldText.text = damageUpgradeGoldCost.ToString();
                break;
            case 1:
                damageUpgradeGoldCost = 20;
                damageUpgradeGoldText.text = damageUpgradeGoldCost.ToString();
                break;
            case 2:
                damageUpgradeGoldCost = 40;
                damageUpgradeGoldText.text = damageUpgradeGoldCost.ToString();
                break;
            case 3:
                damageUpgradeGoldCost = 80;
                damageUpgradeGoldText.text = damageUpgradeGoldCost.ToString();
                break;
            case 4:
                damageUpgradeGoldCost = 160;
                damageUpgradeGoldText.text = damageUpgradeGoldCost.ToString();
                break;
            case 5:
                damageUpgradeGoldText.text = "-";
                damageUpgradeButton.interactable = false;
                damageUpgradeButton.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Max Level!";
                break;
            default:
                break;
        }
    }
    private void CalculateDurabilityGoldCost()
    {
        switch (PlayerPrefs.GetInt("TowerDurability"))
        {
            case 0:
                durabilityUpgradeGoldCost = 10;
                durabilityUpgradeGoldText.text = durabilityUpgradeGoldCost.ToString();
                break;
            case 1:
                durabilityUpgradeGoldCost = 20;
                durabilityUpgradeGoldText.text = durabilityUpgradeGoldCost.ToString();
                break;
            case 2:
                durabilityUpgradeGoldCost = 40;
                durabilityUpgradeGoldText.text = durabilityUpgradeGoldCost.ToString();
                break;
            case 3:
                durabilityUpgradeGoldCost = 80;
                durabilityUpgradeGoldText.text = durabilityUpgradeGoldCost.ToString();
                break;
            case 4:
                durabilityUpgradeGoldCost = 160;
                durabilityUpgradeGoldText.text = durabilityUpgradeGoldCost.ToString();
                break;
            case 5:
                durabilityUpgradeGoldText.text = "-";
                durabilityUpgradeButton.interactable = false;
                durabilityUpgradeButton.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Max Level!";
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("TowerDamage") >= 5)
            {
                damageUpgradeGoldText.text = "-";
                damageUpgradeButton.interactable = false;
                damageUpgradeButton.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Max Level!";
            }
            if (PlayerPrefs.GetInt("TowerDurability") >= 5)
            {
                durabilityUpgradeGoldText.text = "-";
                durabilityUpgradeButton.interactable = false;
                durabilityUpgradeButton.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Max Level!";
            }
            towerUpgraderUIAnimator.SetBool("isOpen", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            towerUpgraderUIAnimator.SetBool("isOpen", false);
        }
    }
}
