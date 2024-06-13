using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode KeyToPress;
    public KeyCode ButtonToPress;
    public bool Missed;
    public bool AlreadyMissed;
    public bool Destroyed;
    public bool hasBeenPressedLastFrame;

    public GameManager gManager;

    public GameObject HitEffect, MissEffect, ToucheExplosion;

    public SpriteRenderer Sprite;
    
    public bool activation = false;
    
    GameObject lastButtonTouched;

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
            canBePressed = false;
            AlreadyMissed = true;
        }*/
    }

    public void Press()
    {
        Destroyed = true;
        GameManager.instance.NoteHit();
        //Instantiate(HitEffect, transform.position,HitEffect.transform.rotation);
        Instantiate (ToucheExplosion,transform.position, ToucheExplosion.transform.rotation);
        gameObject.SetActive(false);
    }

    public void Miss()
    {
        Instantiate(MissEffect, transform.position,MissEffect.transform.rotation);
        GameManager.instance.NoteMissed();
        gameObject.SetActive(false);
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
    }

    public void Activation(bool b)
    {
        activation = b;
        GetComponent<SpriteRenderer>().enabled = activation;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "DeadZone")
        {
            Miss();
        }
    }
}
