using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public float Lifetime = 0.4f;
    public VideoPlayer videoPlayer;
    private bool videocanbePlay = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Collision");
            PlayVideo();
        }
    }
    
    void PlayVideo()
    {
        videoPlayer.Play();
        Destroy(gameObject, Lifetime);
    }
}
