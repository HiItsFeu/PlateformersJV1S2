using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteHolderManager : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject NoteHolder;

    void start()
    {
        NoteHolder.SetActive(false);
    }

    void Update()
    {
        if(GameManager.theMusic.isPlaying)
        {
            Activate();
        }
    }

    void Activate()
    {
        NoteHolder.SetActive(true);
    }
}
