using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SoldierUpgrader : MonoBehaviour
{
    public Animator soldierUpgraderUIAnimator;
    public List<SoldierController> soldiers = new List<SoldierController>();

    [Header ("Attack Upgrade Variables")]
    public TextMeshProUGUI attackUpgradeCostText;
    public Button attackUpgradeButton;
    public int attackUpgradeCost;

    [Header("Health Upgrade Variables")]
    public TextMeshProUGUI healthUpgradeCostText;
    public Button healthUpgradeButton;
    public int healthUpgradeCost;
    private void Start()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Soldier").Length; i++)
        {
            soldiers.Add(GameObject.FindGameObjectsWithTag("Soldier")[i].GetComponent<SoldierController>());
        }
    }
    public void UpgradeAttack()
    {
        if (PlayerPrefs.GetInt("GoldCount") >= attackUpgradeCost)
        {
            PlayerPrefs.SetInt("SoldierAttackPoint", PlayerPrefs.GetInt("SoldierAttackPoint") + 10);
            GameManager.SpendGold(attackUpgradeCost);
        }
    }
    public void UpgradeHealth()
    {
        if (PlayerPrefs.GetInt("GoldCount") >= healthUpgradeCost)
        {
            PlayerPrefs.SetInt("SoldierHealthPoint", PlayerPrefs.GetInt("SoldierHealthPoint") + 20);
            for (int i = 0; i < soldiers.Count; i++)
            {
                soldiers[i].maxHealth = PlayerPrefs.GetInt("SoldierHealthPoint");
                soldiers[i].health = soldiers[i].maxHealth;
            }
            GameManager.SpendGold(healthUpgradeCost);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            soldierUpgraderUIAnimator.SetBool("isOpen", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            soldierUpgraderUIAnimator.SetBool("isOpen", false);
        }
    }
}
