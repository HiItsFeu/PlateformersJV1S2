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

    public Animation NoteExplosion;

    public GameObject HitEffect, MissEffect;

    public SpriteRenderer Sprite;
    
    public bool activation = false;
    GameObject lastButtonTouched;

    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        hasBeenPressedLastFrame = false;
    }
    
    void Update()
    {

        bool bTriggerPressed = false;
        if(KeyToPress == KeyCode.E) bTriggerPressed = Gamepad.current.rightTrigger.wasPressedThisFrame;
        if(KeyToPress == KeyCode.R) bTriggerPressed = Gamepad.current.leftTrigger.wasPressedThisFrame;

        if(Input.GetKeyDown(KeyToPress) || Input.GetKeyDown(ButtonToPress) || bTriggerPressed)
        {
            if(canBePressed)
            {
                Destroyed = true;
                GameManager.instance.NoteHit();
                Instantiate(HitEffect, transform.position,HitEffect.transform.rotation);
                //NoteExplosion.Play();

                if(lastButtonTouched.GetComponent<ButtonController>() != null) lastButtonTouched.GetComponent<ButtonController>().legal = false;
                if(lastButtonTouched.GetComponent<ButtonControllerRed>() != null) lastButtonTouched.GetComponent<ButtonControllerRed>().legal = false;
                if(lastButtonTouched.GetComponent<ButtonControllerGreen>() != null) lastButtonTouched.GetComponent<ButtonControllerGreen>().legal = false;
                if(lastButtonTouched.GetComponent<ButtonControllerYellow>() != null) lastButtonTouched.GetComponent<ButtonControllerYellow>().legal = false;
                lastButtonTouched = null;
                gameObject.SetActive(false);

            }
        }

        if(Missed==true && AlreadyMissed==false)
        {
            canBePressed = false;
            AlreadyMissed = true;
            GameManager.instance.NoteMissed();
            Instantiate(MissEffect, transform.position,MissEffect.transform.rotation);

            if(lastButtonTouched.GetComponent<ButtonController>() != null) lastButtonTouched.GetComponent<ButtonController>().legal = false;
            if(lastButtonTouched.GetComponent<ButtonControllerRed>() != null) lastButtonTouched.GetComponent<ButtonControllerRed>().legal = false;
            if(lastButtonTouched.GetComponent<ButtonControllerGreen>() != null) lastButtonTouched.GetComponent<ButtonControllerGreen>().legal = false;
            if(lastButtonTouched.GetComponent<ButtonControllerYellow>() != null) lastButtonTouched.GetComponent<ButtonControllerYellow>().legal = false;
            lastButtonTouched = null;
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
            lastButtonTouched = other.gameObject;

            if(lastButtonTouched.GetComponent<ButtonController>() != null) lastButtonTouched.GetComponent<ButtonController>().legal = true;
            if(lastButtonTouched.GetComponent<ButtonControllerRed>() != null) lastButtonTouched.GetComponent<ButtonControllerRed>().legal = true;
            if(lastButtonTouched.GetComponent<ButtonControllerGreen>() != null) lastButtonTouched.GetComponent<ButtonControllerGreen>().legal = true;
            if(lastButtonTouched.GetComponent<ButtonControllerYellow>() != null) lastButtonTouched.GetComponent<ButtonControllerYellow>().legal = true;

        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator" && Destroyed==false)
        {
            Missed = true;
            lastButtonTouched = other.gameObject;
        }
    }

    public void Activation(bool b)
    {
        activation = b;
        GetComponent<SpriteRenderer>().enabled = activation;
    }
}
