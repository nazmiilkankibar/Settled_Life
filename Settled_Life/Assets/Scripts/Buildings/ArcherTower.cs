using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArcherTower : MonoBehaviour
{
    public Transform target;
    public GameObject archer;
    public Animator anim;
    public float turnSpeed;
    public float attackSpeed;
    public int damage;

    public float maxDurability;
    public float durability;
    public Image durabilityImage;

    public GameObject arrow;
    public Transform firePoint;
    public ArcherTowerAttackRange archerTowerAttackRange;
    private void Start()
    {
        //anim = GetComponentInChildren<Animator>();
        //archer = transform.GetChild(transform.childCount - 1).gameObject;
        CalculateDamage();
        CalculateDurability();
    }
    private void Update()
    {
        if (target != null)
        {
            archer.transform.rotation = Quaternion.LookRotation(target.position + new Vector3(0, archer.transform.position.y, 0) - archer.transform.position, Vector3.up);
        }
        if (target == null && archerTowerAttackRange.enemies.Count > 0)
        {
            StartCoroutine(Attack());
            target = archerTowerAttackRange.enemies[0];
        }
        if (archerTowerAttackRange.enemies.Count == 0)
        {
            StopAllCoroutines();
            target = null;
        }
        durabilityImage.fillAmount = durability / maxDurability;
    }
    public IEnumerator Attack()
    {
        while (true)
        {
            Invoke("AttackAnim", .3f);
            anim.SetTrigger("Release");
            yield return new WaitForSeconds(attackSpeed);
        }
    }
    public void AttackAnim()
    {
        GameObject arrowObj = Instantiate(arrow, firePoint.transform.position, firePoint.transform.rotation);
        arrowObj.GetComponent<Arrow>().damage = damage;
        arrowObj.GetComponent<Arrow>().target = target;
        if (target != null && target.GetComponent<EnemyController>().isDead)
        {
            archerTowerAttackRange.enemies.Remove(target);
            target = null;
            StopAllCoroutines();
        }
    }
    public void CalculateDamage()
    {
        switch (PlayerPrefs.GetInt("TowerDamage"))
        {
            case 0:
                damage = 10;
                break;
            case 1:
                damage = 15;
                break;
            case 2:
                damage = 20;
                break;
            case 3:
                damage = 25;
                break;
            case 4:
                damage = 30;
                break;
            case 5:
                damage = 35;
                break;
            default:
                break;
        }
    }
    public void CalculateDurability()
    {
        switch (PlayerPrefs.GetInt("TowerDurability"))
        {
            case 0:
                maxDurability = 50;
                durability = maxDurability;
                break;
            case 1:
                maxDurability = 75;
                durability = maxDurability;
                break;
            case 2:
                maxDurability = 100;
                durability = maxDurability;
                break;
            case 3:
                maxDurability = 125;
                durability = maxDurability;
                break;
            case 4:
                maxDurability = 150;
                durability = maxDurability;
                break;
            case 5:
                maxDurability = 200;
                durability = maxDurability;
                break;
            default:
                break;
        }
    }
    public void TakeDamage(int value)
    {
        print("nik");
        durability -= value;
        if (durability <= 0)
        {
            transform.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}
