using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameManager GameManager;
    
    public Transform target;

    public Transform gameObject;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;
    

    void FixedUpdate()
    {
        Vector3 desiredPostion = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp (transform.position, desiredPostion, smoothSpeed);
        transform.position = smoothPosition;

        if(GameManager.startPlaying)
        {
            transform.position = gameObject.position;
        }
    }
}
