using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvaManager : MonoBehaviour
{
    bool activation = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Canva");
            activation = !activation;
            GetComponent<Canvas> ().enabled = activation;
        }
    }
}
