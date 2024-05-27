using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMob : MonoBehaviour
{
    public GameManagerMob1 GameManagerMob1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Collision");
            GameManagerMob1.StartTheGame();
        }
    }
}
