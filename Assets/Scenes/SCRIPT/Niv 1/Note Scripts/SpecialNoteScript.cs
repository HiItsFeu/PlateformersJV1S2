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

    public GameObject HitEffect, MissEffect;

    void Update()
    {
        if(Input.GetKeyDown(KeyToPress))
        {
            if(canBePressed)
            {
                Destroyed = true;
                gameObject.SetActive(false);
                GameManager.instance.SpecialNotes();
                Instantiate(HitEffect, transform.position,HitEffect.transform.rotation);
            }
        }

        if(Missed==true && AlreadyMissed==false)
        {
            canBePressed = false;
            AlreadyMissed = true;
            GameManager.instance.SpecialNoteMissed();
            Instantiate(MissEffect, transform.position,MissEffect.transform.rotation);
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
