using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvaManager : MonoBehaviour
{
    public bool activation = false;

    public void Activation()
    {
        Debug.Log("Canva");
        activation = !activation;
        GetComponent<Canvas> ().enabled = activation;
    }

    public void Unactivated()
    {
        Debug.Log("Canva Desactived");
        activation = !activation;
        GetComponent<Canvas> ().enabled = activation;
    }
}
