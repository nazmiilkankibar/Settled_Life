using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BasicAxe : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (other.CompareTag("Tree"))
            {
                other.GetComponent<Tree>().TakeDamage();
            }
        }
        else
        {
            if (other.CompareTag("Tree"))
            {
                other.GetComponent<Tree>().TakeDamageOnWarScene();
            }
        }
    }
}
