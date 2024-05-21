using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public Transform RespawnPoint;
    public Transform Target;

    void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        transform.position = RespawnPoint.position;
        Target.position = RespawnPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Reset Player"))
        {
            Die();
        }
    }
}
