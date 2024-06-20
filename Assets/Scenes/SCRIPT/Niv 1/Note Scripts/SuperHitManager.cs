using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperHitManager : MonoBehaviour
{
    public float Lifetime = 1f;

    public void Update()
    {
        Destroy(gameObject, Lifetime);
    }
}
