using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WoodMill : MonoBehaviour
{
    public float processRate;
    public int maxStorage;

    private int processUpgradeCost;
    private int maxStorageUpgradeCost;

    public TextMeshPro woodStorageText;
    public TextMeshProUGUI upgradeProcessCostText;
    public TextMeshProUGUI upgradeMaxStorageCostText;

    public Button upgradeProcessButton;
    public Button upgradeMaxStorageButton;

    public Animator woodMillUIAnimator;

    public GameObject wood;
    public float xPos = 0;
    public float yPos = 0;
    public Transform woodPos;
    private void Start()
    {
        CalculateProcessRate();
        CalculateMaxStorage();
        StartCoroutine(CutWood());
    }
    private void CalculateProcessRate()
    {
        switch (PlayerPrefs.GetInt("WoodMillProcessUpgrade"))
        {
            case 0:
                processRate = 2.5f;
                processUpgradeCost = 50;
                upgradeProcessCostText.text = processUpgradeCost.ToString();
                break;
            case 1:
                processRate = 2f;
                processUpgradeCost = 150;
                upgradeProcessCostText.text = processUpgradeCost.ToString();
                break;
            case 2:
                processRate = 1.5f;
                processUpgradeCost = 300;
                upgradeProcessCostText.text = processUpgradeCost.ToString();
                break;
            case 3:
                processRate = 1;
                processUpgradeCost = 600;
                upgradeProcessCostText.text = processUpgradeCost.ToString();
                break;
            case 4:
                processRate = .5f;
                processUpgradeCost = 1200;
                upgradeProcessCostText.text = processUpgradeCost.ToString();
                upgradeProcessButton.interactable = false;
                upgradeProcessButton.GetComponentInChildren<TextMeshProUGUI>().text = "Max level!";
                upgradeProcessCostText.text = "-";
                break;
            default:
                break;
        }
    }
    private void CalculateMaxStorage()
    {
        switch (PlayerPrefs.GetInt("WoodMillMaxStorageUpgrade"))
        {
            case 0:
                maxStorage = 100;
                maxStorageUpgradeCost = 50;
                upgradeMaxStorageCostText.text = maxStorageUpgradeCost.ToString();
                break;
            case 1:
                maxStorage = 200;
                maxStorageUpgradeCost = 150;
                upgradeMaxStorageCostText.text = maxStorageUpgradeCost.ToString();
                break;
            case 2:
                maxStorage = 350;
                maxStorageUpgradeCost = 300;
                upgradeMaxStorageCostText.text = maxStorageUpgradeCost.ToString();
                break;
            case 3:
                maxStorage = 500;
                maxStorageUpgradeCost = 600;
                upgradeMaxStorageCostText.text = maxStorageUpgradeCost.ToString();
                break;
            case 4:
                maxStorage = 1000;
                maxStorageUpgradeCost = 1200;
                upgradeMaxStorageCostText.text = maxStorageUpgradeCost.ToString();
                upgradeMaxStorageButton.interactable = false;
                upgradeMaxStorageButton.GetComponentInChildren<TextMeshProUGUI>().text = "Max level!";
                upgradeMaxStorageCostText.text = "-";
                break;
            default:
                break;
        }
    }
    public void UpgradeProcessRate()
    {
        if (PlayerPrefs.GetInt("GoldCount") >= processUpgradeCost)
        {
            PlayerPrefs.SetInt("WoodMillProcessUpgrade", PlayerPrefs.GetInt("WoodMillProcessUpgrade") + 1);
            PlayerPrefs.SetInt("GoldCount", PlayerPrefs.GetInt("GoldCount") - processUpgradeCost);
            CalculateProcessRate();
            print(PlayerPrefs.GetInt("WoodMillProcessUpgrade"));
        }
    }
    public void UpgradeMaxStorage()
    {
        if (PlayerPrefs.GetInt("GoldCount") >= maxStorageUpgradeCost)
        {
            PlayerPrefs.SetInt("WoodMillMaxStorageUpgrade", PlayerPrefs.GetInt("WoodMillMaxStorageUpgrade") + 1);
            PlayerPrefs.SetInt("GoldCount", PlayerPrefs.GetInt("GoldCount") - maxStorageUpgradeCost);
            CalculateMaxStorage();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("WoodMillMaxStorageUpgrade") > 4)
            {
                upgradeProcessButton.interactable = false;
                upgradeProcessButton.GetComponentInChildren<TextMeshProUGUI>().text = "Max level!!!";
                upgradeProcessCostText.text = "-";
            }
            if (PlayerPrefs.GetInt("WoodMillProcessUpgrade") > 4)
            {
                upgradeMaxStorageButton.interactable = false;
                upgradeMaxStorageButton.GetComponentInChildren<TextMeshProUGUI>().text = "Max level!!!";
                upgradeMaxStorageCostText.text = "-";
            }
            PlayerPrefs.SetInt("WoodCount", PlayerPrefs.GetInt("WoodCount") + PlayerPrefs.GetInt("CurrentWoodStorage"));
            //currentStorage = 0;
            PlayerPrefs.SetInt("CurrentWoodStorage", 0);
            xPos = 0;
            yPos = 0;
            for (int i = 0; i < woodPos.transform.childCount; i++)
            {
                Destroy(woodPos.GetChild(i).gameObject);
            }
            int currentWoodCount = PlayerPrefs.GetInt("CurrentWoodStorage");
            woodStorageText.text = currentWoodCount.ToString() + "/" + maxStorage;
            woodMillUIAnimator.SetBool("isOpen", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            woodMillUIAnimator.SetBool("isOpen", false);
        }
    }
    public void SpawnWood()
    {
        Instantiate(wood, woodPos.position + new Vector3(xPos, yPos, 0), woodPos.rotation, woodPos);
        xPos -= .25f;
        if (xPos <= -5f)
        {
            xPos = 0;
            yPos += .25f;
        }
    }
    private IEnumerator CutWood()
    {
        while (PlayerPrefs.GetInt("CurrentWoodStorage") < maxStorage)
        {
            PlayerPrefs.SetInt("CurrentWoodStorage", PlayerPrefs.GetInt("CurrentWoodStorage") + 1);
            //currentStorage++;
            int currentWoodCount = PlayerPrefs.GetInt("CurrentWoodStorage");
            woodStorageText.text = currentWoodCount.ToString() + "/" + maxStorage;
            yield return new WaitForSeconds(processRate);
        }
    }
}
