using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;

    public bool hasStarted;

    public GameManager GManager;

    void Start()
    {
        beatTempo = beatTempo / 60f;
    }

    void Update()
    {
        if(!hasStarted)
        {
            if(GManager.startPlaying==true)
            {
                hasStarted = true;
            }
        }
        else
        {
             transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
        }
    }
}
