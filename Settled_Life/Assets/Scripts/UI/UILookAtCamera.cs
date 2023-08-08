using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAtCamera : MonoBehaviour
{
    private Transform camPos;
    private void Start()
    {
        camPos = Camera.main.transform;
    }
    private void Update()
    {
        transform.LookAt(camPos);
    }
}
