using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public Transform target;
    private void Update()
    {
        if (target != null)
        {
            if (target.GetComponent<EnemyController>().isDead)
            {
                GetComponentInParent<PlayerController>().anim.SetBool("AttackEnemy", false);
                target = null;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && !other.GetComponent<EnemyController>().isDead)
        {
            target = other.transform;
            GetComponentInParent<PlayerController>().anim.SetBool("AttackEnemy", true);
        }
        if (other.CompareTag("TreeRange"))
        {
            GetComponentInParent<PlayerController>().anim.SetBool("Attack", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GetComponentInParent<PlayerController>().anim.SetBool("AttackEnemy", false);
        }
        if (other.CompareTag("TreeRange"))
        {
            GetComponentInParent<PlayerController>().anim.SetBool("Attack", false);
        }
    }
}
