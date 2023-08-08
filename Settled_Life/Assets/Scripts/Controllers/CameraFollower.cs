using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothTime;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
    [SerializeField] private Transform topDownLook;
    [SerializeField] private Transform closeUpLook;
    public bool inHouse;
    public bool closeUp;
    private void Update()
    {
        if (closeUp)
        {
            smoothTime = .5f;
            transform.position = Vector3.SmoothDamp(transform.position, closeUpLook.position, ref velocity, smoothTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, closeUpLook.rotation, 2 * Time.deltaTime);
        }
        else if(inHouse)
        {
            smoothTime = 2f;
            transform.position = Vector3.SmoothDamp(transform.position, topDownLook.position, ref velocity, smoothTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, topDownLook.rotation, 2 * Time.deltaTime);
        }
        else
        {
            smoothTime = .5f;
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(60, 0, 0), 2 * Time.deltaTime);
        }
        
        
    }
}
