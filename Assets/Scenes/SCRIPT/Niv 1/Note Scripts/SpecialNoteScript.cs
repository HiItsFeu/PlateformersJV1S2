using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpecialNote : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode KeyToPress;
    public KeyCode ButtonToPress;
    public bool Missed;
    public bool AlreadyMissed;
    public bool Destroyed;

    public GameManager gManager;

    public GameObject HitEffect, MissEffect, ToucheExplosion;

    public SpriteRenderer Sprite;
    
    public bool activation = false;

    GameObject lastButtonTouched;
    public bool SpeciaNotePress = false;

    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        /*bool bTriggerPressed = false;
        if(KeyToPress == KeyCode.E) bTriggerPressed = Gamepad.current.rightTrigger.wasPressedThisFrame;
        if(KeyToPress == KeyCode.R) bTriggerPressed = Gamepad.current.leftTrigger.wasPressedThisFrame;

        if(Input.GetKeyDown(KeyToPress) || Input.GetKeyDown(ButtonToPress) || bTriggerPressed)
        {
            if(canBePressed)
            {
            }
        }

        if(Missed==true && AlreadyMissed==false)
        {

        }*/
    }

    public void SpecialNotePress()
    {
        Destroyed = true;
        SpeciaNotePress = true;
        gameObject.SetActive(false);
        GameManager.instance.SpecialNotes();
        //Instantiate(HitEffect, transform.position,HitEffect.transform.rotation);
        Instantiate (ToucheExplosion,transform.position, ToucheExplosion.transform.rotation);
    }

    public void SpecialNoteMiss()
    {
        GameManager.instance.NoteMissed();
        gameObject.SetActive(false);
        Instantiate(MissEffect, transform.position,MissEffect.transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "DeadZone")
        {
            SpecialNoteMiss();
        }
    }

    void FixedUpdate()
    {
        if(gManager.startPlaying==true)
        {
            Activation(true);
        }
        else 
        {
            Activation(false);
        }
        
        if(gManager.gameHasEnded==true)
        {
            gameObject.SetActive(false);
        }
    }

    public void Activation(bool b)
    {
        activation = b;
        GetComponent<SpriteRenderer>().enabled = activation;
    }
}
