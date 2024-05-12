using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalexEffect : MonoBehaviour
{
    Material mat;
    float distance;

    [Range(0f, 0.5f)]
    public float speed = 0.2f;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        distance += Time.deltaTime * speed;
        mat.SetTextureOffset("MainTex", Vector2.right * distance);
    }
}
