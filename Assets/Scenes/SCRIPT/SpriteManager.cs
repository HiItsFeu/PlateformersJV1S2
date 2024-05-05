using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    private SpriteRenderer Sprite;
    bool activation = false;
    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            activation = !activation;
            GetComponent<SpriteRenderer>().enabled = activation;
        }
    }
}
