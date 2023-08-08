using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().TakeDamage(damage);
        }
        if (other.CompareTag("Soldier"))
        {
            other.GetComponent<SoldierController>().TakeDamage(damage);
        }
        if (other.CompareTag("Tower"))
        {
            other.GetComponent<ArcherTower>().TakeDamage(damage);
        }
    }
}
