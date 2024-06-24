using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMob : MonoBehaviour
{
    public ResetPlayer ResetPlayer;

   /* private float Speed = 4f;
    Vector2 position;
    Vector2 target;

    void Start()
    {
        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;
    }

    void Update()
    {
        float step = Speed * Time.deltaTime;
        transform.position = transform.position + new Vector3(-Time.deltaTime, 0, 0);
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Collision");
            ResetPlayer.Die();
        }
    }
}
