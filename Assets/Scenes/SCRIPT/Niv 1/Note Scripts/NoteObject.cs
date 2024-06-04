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

    public GameManager gManager;

    public Animation NoteExplosion;

    public GameObject HitEffect, MissEffect;

    public SpriteRenderer Sprite;
    
    public bool activation = false;
    GameObject lastButtonTouched;

    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
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
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();
                Instantiate(HitEffect, transform.position,HitEffect.transform.rotation);
                //NoteExplosion.Play();

                if(lastButtonTouched.GetComponent<ButtonController>() != null) lastButtonTouched.GetComponent<ButtonController>().legal = false;
                if(lastButtonTouched.GetComponent<ButtonControllerRed>() != null) lastButtonTouched.GetComponent<ButtonControllerRed>().legal = false;
                if(lastButtonTouched.GetComponent<ButtonControllerGreen>() != null) lastButtonTouched.GetComponent<ButtonControllerGreen>().legal = false;
                if(lastButtonTouched.GetComponent<ButtonControllerYellow>() != null) lastButtonTouched.GetComponent<ButtonControllerYellow>().legal = false;

            }
        }

        if(Missed==true && AlreadyMissed==false)
        {
            canBePressed = false;
            AlreadyMissed = true;
            GameManager.instance.NoteMissed();
            Instantiate(MissEffect, transform.position,MissEffect.transform.rotation);
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
            if(other.GetComponent<ButtonController>() != null) other.GetComponent<ButtonController>().legal = true;
            if(other.GetComponent<ButtonControllerRed>() != null) other.GetComponent<ButtonControllerRed>().legal = true;
            if(other.GetComponent<ButtonControllerGreen>() != null) other.GetComponent<ButtonControllerGreen>().legal = true;
            if(other.GetComponent<ButtonControllerYellow>() != null) other.GetComponent<ButtonControllerYellow>().legal = true;

            lastButtonTouched = other.gameObject;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator" && Destroyed==false)
        {
            Missed = true;
            if(other.GetComponent<ButtonController>() != null) other.GetComponent<ButtonController>().legal = false;
            if(other.GetComponent<ButtonControllerRed>() != null) other.GetComponent<ButtonControllerRed>().legal = false;
            if(other.GetComponent<ButtonControllerGreen>() != null) other.GetComponent<ButtonControllerGreen>().legal = false;
            if(other.GetComponent<ButtonControllerYellow>() != null) other.GetComponent<ButtonControllerYellow>().legal = false;
        }
    }

    public void Activation(bool b)
    {
        activation = b;
        GetComponent<SpriteRenderer>().enabled = activation;
    }
}
