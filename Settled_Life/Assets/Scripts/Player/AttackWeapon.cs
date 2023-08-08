using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWeapon : MonoBehaviour
{
    public int damage;
    public int force;
    public GameObject bloodFX;
    private TrailRenderer trailFX;
    private PlayerController player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        trailFX = transform.GetChild(0).GetComponent<TrailRenderer>();
    }
    private void Update()
    {
        if (player.anim.GetCurrentAnimatorStateInfo(1).IsName("Attack Enemy"))
        {
            GetComponent<BoxCollider>().enabled = true;
            trailFX.enabled = true;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = false;
            trailFX.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().TakeDamage(damage);
            other.GetComponent<Rigidbody>().AddForce(-other.transform.forward * force, ForceMode.Impulse);
        }
    }
}
