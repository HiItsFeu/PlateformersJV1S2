using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life2Manager : MonoBehaviour
{
    public float Lifetime = 0.2f;

    void Update()
    {
        Destroy(gameObject, Lifetime);
    }
}
