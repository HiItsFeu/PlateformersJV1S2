using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperHitEffect : MonoBehaviour
{
    public float Lifetime = 1f;

    void Update()
    {
        Destroy(gameObject, Lifetime);
    }
}
