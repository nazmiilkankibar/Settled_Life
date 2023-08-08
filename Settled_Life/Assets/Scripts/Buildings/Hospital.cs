using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Hospital : MonoBehaviour
{
    PlayerController player;
    public int regeneratePlayerGoldCost;
    public int regenerateSoldierGoldCost;

    public Animator hospitalUIAnimator;

    private List<SoldierController> soldiers = new List<SoldierController>();

    public Transform spawnPos;
    public TextMeshProUGUI playerRegenerateCostText;
    public TextMeshProUGUI soldierRegenerateCostText;
    private void Start()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Soldier").Length; i++)
        {
            soldiers.Add(GameObject.FindGameObjectsWithTag("Soldier")[i].GetComponent<SoldierController>());
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        TextUpdate();
    }
    public void RegeneratePlayerHealth()
    {
        if (PlayerPrefs.GetInt("GoldCount") >= regeneratePlayerGoldCost && player.health < player.maxHealth)
        {
            player.health = PlayerPrefs.GetFloat("PlayerHealth");
            GameManager.SpendGold(regeneratePlayerGoldCost);
            TextUpdate();
        }
    }
    public void RegenerateSoldiersHealth()
    {
        if (PlayerPrefs.GetInt("GoldCount") >= regenerateSoldierGoldCost)
        {
            for (int i = 0; i < soldiers.Count; i++)
            {
                SoldierController soldier = soldiers[i];
                if (soldier.isDead)
                {
                    soldier.gameObject.SetActive(true);
                    soldier.GetComponent<CapsuleCollider>().enabled = true;
                    soldier.isDead = false;
                    soldier.health = soldier.maxHealth;
                    soldier.transform.position = spawnPos.position;
                }
                else
                {
                    soldier.health = soldier.maxHealth;
                }
            }
            GameManager.SpendGold(regenerateSoldierGoldCost);
            TextUpdate();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hospitalUIAnimator.SetBool("isOpen", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hospitalUIAnimator.SetBool("isOpen", false);
        }
    }
    private void TextUpdate()
    {
        playerRegenerateCostText.text = regeneratePlayerGoldCost.ToString();
        soldierRegenerateCostText.text = regenerateSoldierGoldCost.ToString();
    }
}
