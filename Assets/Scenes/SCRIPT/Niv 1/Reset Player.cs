using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public Transform RespawnPoint;
    public Transform Target;
    public AudioSource RespawnSFX;

    public void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        transform.position = RespawnPoint.position;
        Target.position = RespawnPoint.position;
        RespawnSFX.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Reset Player"))
        {
            Die();
        }
    }
}
