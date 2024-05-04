using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialNote : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode KeyToPress;
    public bool Missed;
    public bool AlreadyMissed;
    public bool Destroyed;

    void Update()
    {
        if(Input.GetKeyDown(KeyToPress))
        {
            if(canBePressed)
            {
                Destroyed = true;
                gameObject.SetActive(false);
                GameManager.instance.SpecialNotes();
            }
        }

        if(Missed==true && AlreadyMissed==false)
        {
            canBePressed = false;
            AlreadyMissed = true;
            GameManager.instance.SpecialNoteMissed();
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
