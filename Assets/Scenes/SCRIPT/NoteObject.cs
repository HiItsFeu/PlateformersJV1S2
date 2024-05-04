using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode KeyToPress;
    public bool Missed;
    public bool AlreadyMissed;
    public bool Destroyed;
    //public GameManager GameManager;

    void Start()
    {
        gameObject.tag = "SpecialNote";
    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyToPress))
        {
            if(canBePressed)
            {
                Destroyed = true;
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();
            }
            
            if(gameObject.tag == "SpecialNote")
            {
                GameManager.instance.SpecialNotes();
            }
        }

        if(Missed==true && AlreadyMissed==false)
        {
            canBePressed = false;
            AlreadyMissed = true;
            GameManager.instance.NoteMissed();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator" && Destroyed==false)
        {
            Missed = true;
        }
    }
}
