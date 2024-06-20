using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFeedBackManager : MonoBehaviour
{
    public float Lifetime = 0.2f;

    void Update()
    {
        Destroy(gameObject, Lifetime);
    }
}
