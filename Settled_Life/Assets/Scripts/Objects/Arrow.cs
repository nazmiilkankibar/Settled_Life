using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage;
    public Transform target;
    public float speed;
    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position + new Vector3(0, 1, 0), speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(target.position + new Vector3(0, 1, 0) - transform.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
