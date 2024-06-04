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

    public GameObject HitEffect, MissEffect;

    public SpriteRenderer Sprite;
    public bool activation = false;

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
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator" && Destroyed==false)
        {
            Missed = true;
        }
    }

    public void Activation(bool b)
    {
        activation = b;
        GetComponent<SpriteRenderer>().enabled = activation;
    }
}
