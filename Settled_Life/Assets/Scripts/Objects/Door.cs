using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Quaternion baseRotation;
    private void Start()
    {
        baseRotation = transform.rotation;
    }
    private void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, baseRotation, 720 * Time.deltaTime);
    }
}
