using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAxe : MonoBehaviour
{
    public int damage;
    public int force;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            damage = PlayerPrefs.GetInt("SoldierAttackPoint");
            other.GetComponent<EnemyController>().TakeDamage(damage);
            other.GetComponent<Rigidbody>().AddForce(-other.transform.forward * force, ForceMode.Impulse);
        }
    }
}
