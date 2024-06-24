using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    public float Lifetime = 0.4f;
    public GameManager GManager;
    public VideoPlayer videoPlayer;

    void Update()
    {
        if(GManager.DuelWin==true)
        {
            videoPlayer.Play();
            Destroy(gameObject, Lifetime);
        }
    }
}
