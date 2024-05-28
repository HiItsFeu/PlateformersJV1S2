using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteHolderManager : MonoBehaviour
{
    public bool activation = false;

    public SpriteRenderer Sprite;
    
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
