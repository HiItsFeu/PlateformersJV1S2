using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource Music;

    public AudioClip[] RandomMusic;

    void start()
    {
        Music = GetComponent<AudioSource>();
    }
    
    void Awake()
    {
        Music.clip=RandomMusic[Random.Range(0,RandomMusic.Length)];
        Music.Play();
    }
}
