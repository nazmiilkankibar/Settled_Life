using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
public class SoldierController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private Transform patrolPointParent;
    private List<Transform> patrolPoints = new List<Transform>();

    private Transform target;
    private EvilGate evilGate;
    public GameObject bloodFX;

    public bool isDead;

    public Image healthBar;
    public float maxHealth;
    public float health;
    public TextMeshProUGUI healthText;
    private void Start()
    {
        health = maxHealth;
        isDead = false;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        evilGate = GameObject.FindGameObjectWithTag("EvilGate").GetComponent<EvilGate>();
        patrolPointParent = GameObject.FindGameObjectWithTag("PatrolPoints").transform;
        for (int i = 0; i < patrolPointParent.childCount; i++)
        {
            patrolPoints.Add(patrolPointParent.GetChild(i));
        }
        ChoosePath();
    }
    private void Update()
    {
        if (isDead)
        {
            return;
        }
        else
        {
            HealthBar();
            if (target == null)
            {
                ChoosePath();
            }
            if (Vector3.Distance(transform.position, target.position) < agent.stoppingDistance && !isDead)
            {
                ChoosePath();
            }
            else
            {
                if (evilGate.spawnedEnemies.Count > 0)
                {
                    target = evilGate.spawnedEnemies[0].transform;
                    if (Vector3.Distance(transform.position, target.position) > agent.stoppingDistance)
                    {
                        MoveToEnemy();
                    }
                    else
                    {
                        Attack();
                    }
                }
                else
                {
                    PatrolMovement();
                }
            }
        }
    }
    private void Attack()
    {
        anim.SetBool("Attack", true);
        if (Vector3.Distance(transform.position,target.position) < agent.stoppingDistance)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }
    private void PatrolMovement()
    {
        anim.SetBool("Attack", false);
        if (agent.hasPath)
        {
            agent.speed = 1.25f;
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        agent.SetDestination(target.position);
    }
    private void MoveToEnemy()
    {
        anim.SetBool("Attack", false);
        if (agent.hasPath)
        {
            agent.speed = 3;
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        agent.SetDestination(target.position);
    }
    private void ChoosePath()
    {
        int randomInt = Random.Range(0, patrolPoints.Count);
        target = patrolPoints[randomInt];
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(bloodFX, transform.position, Quaternion.identity, transform);
        if (health <= 0)
        {
            transform.GetComponent<CapsuleCollider>().enabled = false;
            isDead = true;
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", false);
            anim.SetTrigger("Death");
        }
    }
    public void Death()
    {
        transform.gameObject.SetActive(false);
    }
    void HealthBar()
    {
        healthBar.fillAmount = (health / maxHealth);
        healthText.text = health.ToString();
    }
}
