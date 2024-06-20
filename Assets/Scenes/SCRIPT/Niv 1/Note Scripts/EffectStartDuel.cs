using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStartDuel : MonoBehaviour
{
    public float Lifetime = 2f;

    void Update()
    {
        Destroy(gameObject, Lifetime);
    }
}
