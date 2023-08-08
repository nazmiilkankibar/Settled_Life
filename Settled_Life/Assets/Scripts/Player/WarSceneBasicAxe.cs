using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarSceneBasicAxe : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            other.GetComponent<Tree>().TakeDamageOnWarScene();
        }
    }
}
