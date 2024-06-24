using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicThemeManager : MonoBehaviour
{
    public GameManager GManager;
    public AudioSource _MainMusic;

    void Update()
    {
        if(GManager.startPlaying==true)
        {
            _MainMusic.Stop();
        }
    }
}
