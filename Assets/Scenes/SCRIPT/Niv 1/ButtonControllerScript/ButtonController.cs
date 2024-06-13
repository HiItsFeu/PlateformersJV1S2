using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonController : MonoBehaviour
{
    public SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    
    public GameManager GameManager;

    public NoteObject LastNoteHit;

    public SpecialNote LastSpecialNoteHit;

    public KeyCode KeyToPress;

    public KeyCode JoystickToPress;

    bool activation = false;

    public bool bLeftTriggerToPress;

    public bool bRightTriggerToPress;

    bool bOtherToPress;

    bool bOtherToRelease;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(bLeftTriggerToPress == true)
        {
            bOtherToPress = Gamepad.current.leftTrigger.wasPressedThisFrame;
            bOtherToRelease = Gamepad.current.leftTrigger.wasReleasedThisFrame;
        }

        else if(bRightTriggerToPress == true)
        {
            bOtherToPress = Gamepad.current.rightTrigger.wasPressedThisFrame;
            bOtherToRelease = Gamepad.current.rightTrigger.wasReleasedThisFrame;
        }
        
        else
        {
            bOtherToPress = false;
            bOtherToRelease = false;
        }

        if(Input.GetKeyDown(KeyToPress) ||Input.GetKeyDown(JoystickToPress) || bOtherToPress)
        {
            theSR.sprite = pressedImage;
            if(GameManager.startPlaying==true)
            {
                if(LastNoteHit == null && LastSpecialNoteHit == null)
                {
                    GameManager.NoteMissed();
                    Debug.Log("Miss");
                }
                else
                {
                    LastNoteHit.Press();
                    LastNoteHit = null;
                }

                if(LastNoteHit != null && LastSpecialNoteHit == null)
                {
                    GameManager.NoteMissed();
                    Debug.Log("Special Miss");
                }
                
                if(LastSpecialNoteHit != null)
                {
                    LastSpecialNoteHit.SpecialNotePress();
                    LastSpecialNoteHit = null;
                }
            }
            
        }

        if(Input.GetKeyUp(KeyToPress) || Input.GetKeyUp(JoystickToPress) || bOtherToRelease)
        {
            theSR.sprite = defaultImage;
        }


    }

    public void Activation()
    {
        activation = !activation;
        GetComponent<SpriteRenderer>().enabled = activation;
    }

    public void Unactivated()
    {
        activation = !activation;
        GetComponent<SpriteRenderer>().enabled = activation;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<NoteObject>() != null)
        {
            LastNoteHit = other.GetComponent<NoteObject>();
        }
        if(other.GetComponent<SpecialNote>() != null)
        {
            LastSpecialNoteHit = other.GetComponent<SpecialNote>();
        }
    }

    /*void OnTriggerExit2D(Collider2D other)
    {
        if(other.GetComponent<NoteObject>() != null && LastNoteHit != null)
        {
            other.GetComponent<NoteObject>().Miss();
            LastNoteHit = null;
        }
    }*/
}
