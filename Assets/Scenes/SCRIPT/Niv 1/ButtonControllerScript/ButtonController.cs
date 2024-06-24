using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

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

    public GameObject SHManager;
    public GameObject FireFeedBackManager;
    public GameObject FireFeedBackManager2;
    
    public GameObject Canva;
    public GameObject ScoreEvent;
    public GameObject HitEvent;
    
    public GameObject HitEffect;
    public GameObject SuperHitEffect;

    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life1Slash;
    public GameObject CanvaD;

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
                    Instantiate (Life2,CanvaD.transform);
                }
                else
                {
                    LastNoteHit.Press();
                    LastNoteHit = null;
                    Instantiate (FireFeedBackManager);
                    Instantiate (FireFeedBackManager2);
                    GameObject go = Instantiate (ScoreEvent,Canva.transform);
                    go.GetComponent<TMP_Text>().text = "+ " + GameManager.instance.scorePerNote * GameManager.instance.currentMultiplier;
                    Instantiate (HitEvent,Canva.transform);
                    Instantiate (HitEffect);
                    if(GameManager.currentHealth <= GameManager.maxHealth)
                    {
                        Instantiate (Life1,CanvaD.transform);
                    }
                }

                if(LastNoteHit != null && LastSpecialNoteHit == null)
                {
                    GameManager.NoteMissed();
                    Debug.Log("Special Miss");
                    Instantiate (Life2,CanvaD.transform);
                }
                
                if(LastSpecialNoteHit != null)
                {
                    LastSpecialNoteHit.SpecialNotePress();
                    LastSpecialNoteHit = null;
                    Instantiate (SHManager);
                    Instantiate (FireFeedBackManager);
                    Instantiate (FireFeedBackManager2);
                    Instantiate (SuperHitEffect);
                    Instantiate (Life1Slash,CanvaD.transform);
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
