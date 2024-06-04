using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManagerManche : MonoBehaviour
{
    public SpriteRenderer SpriteManche;
    public Material newMaterial;
    public bool activation = false;
    private float speed = 0.08f;
    
    public void Start()
    {
        SpriteManche = GetComponent<SpriteRenderer>();
        //Object.GetComponent<SpriteRenderer>().material = newMaterial;
        newMaterial = GetComponent<SpriteRenderer>().material;
        //ScrollBar = new Vector2(0.0f, 0.0f);
    }

    public void Update()
    {
        float offset = Time.time * speed;
        //transform.position = transform.position + new Vector3(-Time.deltaTime, 0, 0);
        newMaterial.SetTextureOffset("_MainTex", new Vector2(offset, 0));
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
