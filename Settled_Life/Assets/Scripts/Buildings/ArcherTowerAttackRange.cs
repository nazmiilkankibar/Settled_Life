using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTowerAttackRange : MonoBehaviour
{
    ArcherTower tower;
    public List<Transform> enemies = new List<Transform>();
    private void Start()
    {
        tower = GetComponentInParent<ArcherTower>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemies.Add(other.transform);
            other.GetComponent<EnemyController>().archerTowerTargetList.Add(this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemies.Remove(other.transform);
            other.GetComponent<EnemyController>().archerTowerTargetList.Remove(this);
        }
    }
}
