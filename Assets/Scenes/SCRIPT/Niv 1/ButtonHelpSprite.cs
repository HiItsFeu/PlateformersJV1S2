using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHelpSprite : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public bool activation = false;
    
    public void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
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
