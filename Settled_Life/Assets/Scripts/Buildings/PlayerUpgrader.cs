using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerUpgrader : MonoBehaviour
{
    public Animator playerUpgraderUIAnimator;
    public TextMeshProUGUI upgradeHealthCostText;
    public TextMeshProUGUI upgradeSpeedCostText;

    public Button upgradeHealthButton;
    public Button upgradeSpeedButton;

    private int upgradeHealthCost;
    private int upgradeSpeedCost;

    private PlayerController player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        CalculateHealthCost();
        CalculateSpeedCost();
    }
    private void CalculateHealthCost()
    {
        switch (PlayerPrefs.GetInt("PlayerHealthUpgrade"))
        {
            case 0:
                PlayerPrefs.SetFloat("PlayerHealth", 25);
                upgradeHealthCost = 25;
                upgradeHealthCostText.text = upgradeHealthCost.ToString();
                player.maxHealth = PlayerPrefs.GetFloat("PlayerHealth");
                player.health = player.maxHealth;
                break;
            case 1:
                PlayerPrefs.SetFloat("PlayerHealth", 50);
                upgradeHealthCost = 50;
                upgradeHealthCostText.text = upgradeHealthCost.ToString();
                player.maxHealth = PlayerPrefs.GetFloat("PlayerHealth");
                player.health = player.maxHealth;
                break;
            case 2:
                PlayerPrefs.SetFloat("PlayerHealth", 100);
                upgradeHealthCost = 100;
                upgradeHealthCostText.text = upgradeHealthCost.ToString();
                player.maxHealth = PlayerPrefs.GetFloat("PlayerHealth");
                player.health = player.maxHealth;
                break;
            case 3:
                PlayerPrefs.SetFloat("PlayerHealth", 150);
                upgradeHealthCost = 200;
                upgradeHealthCostText.text = upgradeHealthCost.ToString();
                player.maxHealth = PlayerPrefs.GetFloat("PlayerHealth");
                player.health = player.maxHealth;
                break;
            case 4:
                PlayerPrefs.SetFloat("PlayerHealth", 200);
                upgradeHealthCost = 400;
                upgradeHealthCostText.text = upgradeHealthCost.ToString();
                player.maxHealth = PlayerPrefs.GetFloat("PlayerHealth");
                player.health = player.maxHealth;
                upgradeHealthCostText.text = "-";
                upgradeHealthButton.interactable = false;
                upgradeHealthButton.GetComponentInChildren<TextMeshProUGUI>().text = "Max level!";
                break;
            default:
                break;
        }
    }
    private void CalculateSpeedCost()
    {
        switch (PlayerPrefs.GetInt("PlayerSpeedUpgrade"))
        {
            case 0:
                PlayerPrefs.SetFloat("PlayerSpeed", 5);
                upgradeSpeedCost = 25;
                upgradeSpeedCostText.text = upgradeSpeedCost.ToString();
                player.speed = PlayerPrefs.GetFloat("PlayerSpeed");
                break;
            case 1:
                PlayerPrefs.SetFloat("PlayerSpeed", 5.5f);
                upgradeSpeedCost = 50;
                upgradeSpeedCostText.text = upgradeSpeedCost.ToString();
                player.speed = PlayerPrefs.GetFloat("PlayerSpeed");
                break;
            case 2:
                PlayerPrefs.SetFloat("PlayerSpeed", 6f);
                upgradeSpeedCost = 100;
                upgradeSpeedCostText.text = upgradeSpeedCost.ToString();
                player.speed = PlayerPrefs.GetFloat("PlayerSpeed");
                break;
            case 3:
                PlayerPrefs.SetFloat("PlayerSpeed", 6.5f);
                upgradeSpeedCost = 200;
                upgradeSpeedCostText.text = upgradeSpeedCost.ToString();
                player.speed = PlayerPrefs.GetFloat("PlayerSpeed");
                break;
            case 4:
                PlayerPrefs.SetFloat("PlayerSpeed", 7);
                upgradeSpeedCost = 400;
                upgradeSpeedCostText.text = upgradeSpeedCost.ToString();
                player.speed = PlayerPrefs.GetFloat("PlayerSpeed");
                upgradeSpeedCostText.text = "-";
                upgradeSpeedButton.interactable = false;
                upgradeSpeedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Max level!";
                break;
            default:
                break;
        }
    }
    public void UpgradeHealth()
    {
        if (PlayerPrefs.GetInt("GoldCount") >= upgradeHealthCost && PlayerPrefs.GetInt("PlayerHealthUpgrade") < 5)
        {
            GameManager.SpendGold(upgradeHealthCost);
            PlayerPrefs.SetInt("PlayerHealthUpgrade", PlayerPrefs.GetInt("PlayerHealthUpgrade") + 1);
            CalculateHealthCost();
        }
    }
    public void UpgradeSpeed()
    {
        if (PlayerPrefs.GetInt("GoldCount") >= upgradeSpeedCost && PlayerPrefs.GetInt("PlayerSpeedUpgrade") < 5)
        {
            GameManager.SpendGold(upgradeSpeedCost);
            PlayerPrefs.SetInt("PlayerSpeedUpgrade", PlayerPrefs.GetInt("PlayerSpeedUpgrade") + 1);
            CalculateSpeedCost();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerUpgraderUIAnimator.SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerUpgraderUIAnimator.SetBool("isOpen", false);
        }
    }
}
