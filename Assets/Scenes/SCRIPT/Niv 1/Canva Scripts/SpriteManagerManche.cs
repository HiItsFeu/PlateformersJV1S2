using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManagerManche : MonoBehaviour
{
    public SpriteRenderer SpriteManche;
    public bool activation = false;
    
    public void Start()
    {
        SpriteManche = GetComponent<SpriteRenderer>();
    }

    public void Activation()
    {
        activation = !activation;
        GetComponent<SpriteRenderer>().enabled = activation;
    }

    public void Unactivated()
    {
        activation = !activation;
        GetComponent<SpriteRenderer>().enabled = activation;
    }
}
