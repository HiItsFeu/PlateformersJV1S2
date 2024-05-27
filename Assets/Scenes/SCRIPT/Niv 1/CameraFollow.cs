using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    public bool CameraIsFollowing=true;

    public void start()
    {
        CameraIsFollowing = true;
    }
    

    public void FixedUpdate()
    {
        if(CameraIsFollowing==true)
        {
            Vector3 desiredPostion = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp (transform.position, desiredPostion, smoothSpeed);
            transform.position = smoothPosition;
        }
    }
}
