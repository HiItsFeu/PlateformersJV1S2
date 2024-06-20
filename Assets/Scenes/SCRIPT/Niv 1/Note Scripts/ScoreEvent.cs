using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEvent : MonoBehaviour
{
    public float Lifetime = 0.5f;

    void Update()
    {
        Destroy(gameObject, Lifetime);
    }
}
