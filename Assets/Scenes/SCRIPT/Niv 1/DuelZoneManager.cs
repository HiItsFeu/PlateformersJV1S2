using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelZoneManager : MonoBehaviour
{
    public GameManager GManager;
    public bool DuelCanBeStart = false;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            DuelCanBeStart = true;
        }
    }
}
