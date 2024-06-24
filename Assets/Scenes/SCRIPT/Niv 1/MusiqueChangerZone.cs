using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusiqueChangerZone : MonoBehaviour
{
    public GameManager GManager;
    public bool MusicCanBeChanged = false;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            MusicCanBeChanged = true;
        }
    }
}
