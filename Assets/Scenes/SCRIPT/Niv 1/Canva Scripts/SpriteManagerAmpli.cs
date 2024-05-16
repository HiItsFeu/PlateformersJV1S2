using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManagerAmpli : MonoBehaviour
{
    public SpriteRenderer SpriteAmpli;
    public bool activation = false;
    
    public void Start()
    {
        SpriteAmpli = GetComponent<SpriteRenderer>();
    }

    public void ActivationAmpli()
    {
        activation = !activation;
        GetComponent<SpriteRenderer>().enabled = activation;
    }

    public void UnactivatedAmpli()
    {
        activation = !activation;
        GetComponent<SpriteRenderer>().enabled = activation;
    }
}
