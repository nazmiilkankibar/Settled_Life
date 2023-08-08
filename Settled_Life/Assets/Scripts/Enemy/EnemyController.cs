using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EnemyController : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    private Animator anim;

    //Health
    public Image healthBar;
    [SerializeField] private float maxHealth;
    private float health;
    public bool isDead;

    private List<Transform> targets = new List<Transform>();
    public List<ArcherTowerAttackRange> archerTowerTargetList = new List<ArcherTowerAttackRange>();
    public SoldierTrigger soldierTrigger;
    public EvilGate evilGate;

    public GameObject bloodFX;

    private GameController gameController;
    public GameObject goldCoin;
    private void Start()
    {
        SetYourLife();
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }
        targets.Add(GameObject.FindGameObjectWithTag("Player").transform);
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Tower").Length; i++)
        {
            targets.Add(GameObject.FindGameObjectsWithTag("Tower")[i].transform);
        }
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Soldier").Length; i++)
        {
            targets.Add(GameObject.FindGameObjectsWithTag("Soldier")[i].transform);
        }
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        health = maxHealth;
        ChooseTarget();
    }
    private void Update()
    {
        if (target.CompareTag("Soldier"))
        {
            agent.stoppingDistance = 2;
            if (target.GetComponent<SoldierController>().isDead)
            {
                targets.Remove(target);
                ChooseTarget();
            }
        }
        if (target.CompareTag("Tower"))
        {
            agent.stoppingDistance = 3;
            if (target.GetComponent<ArcherTower>().durability <= 0)
            {
                archerTowerTargetList.Remove(target.GetComponent<ArcherTowerAttackRange>());
                targets.Remove(target);
                ChooseTarget();
            }
        }
        if (isDead)
        {
            agent.isStopped = true;
            anim.SetBool("Death", true);
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            Destroy(this.gameObject, 5f);
            return;
        }
        else
        {
            if (Vector3.Distance(transform.position,target.position) > agent.stoppingDistance)
            {
                anim.SetBool("isRunning", true);
                agent.isStopped = false;
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
                anim.SetBool("isRunning", false);
                anim.SetTrigger("Attack");
                agent.isStopped = true;
            }
            HealthBar();
            Death();
            agent.SetDestination(target.position);
        }
    }
    void HealthBar()
    {
        healthBar.fillAmount = (health / maxHealth);
    }
    private void Death()
    {
        if (health <= 0)
        {
            healthBar.transform.parent.gameObject.SetActive(false);
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                isDead = true;
                for (int i = 0; i < archerTowerTargetList.Count; i++)
                {
                    archerTowerTargetList[i].enemies.Remove(this.transform);
                }
                evilGate.spawnedEnemies.Remove(this.gameObject);
            }
            else
            {
                isDead = true;
                gameController.spawnedEnemies.Remove(this.gameObject);
                if (gameController.spawnedEnemies.Count <= 0)
                {
                    gameController.isGameEnded = true;
                }
            }
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                int goldCount = Random.Range(0, 3);
                for (int i = 0; i < goldCount; i++)
                {
                    GameObject coin = Instantiate(goldCoin, transform.position + new Vector3(0, 5, 0), transform.rotation);
                    coin.GetComponent<Rigidbody>().AddTorque(Vector3.forward * 100);
                }
            }
            
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(bloodFX, transform.position, Quaternion.identity,transform);
    }
    private void ChooseTarget()
    {
        float maxDistance = 1000;
        for (int i = 0; i < targets.Count; i++)
        {
            float distance = Vector3.Distance(targets[i].transform.position, transform.position);
            if (distance < maxDistance)
            {
                maxDistance = distance;
                target = targets[i];
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SoldierTrigger"))
        {
            soldierTrigger = other.GetComponent<SoldierTrigger>();
            soldierTrigger.enemies.Add(this.gameObject);
        }
    }
    private void SetYourLife()
    {
        switch (PlayerPrefs.GetInt("WeaponUpgrade"))
        {
            case 0:
                maxHealth = 20;
                break;
            case 1:
                maxHealth = 25;
                break;
            case 2:
                maxHealth = 30;
                break;
            case 3:
                maxHealth = 35;
                break;
            case 4:
                maxHealth = 40;
                break;
            case 5:
                maxHealth = 45;
                break;
            case 6:
                maxHealth = 50;
                break;
            case 7:
                maxHealth = 55;
                break;
            case 8:
                maxHealth = 60;
                break;
            case 9:
                maxHealth = 65;
                break;
            default:
                break;
        }
    }
}
