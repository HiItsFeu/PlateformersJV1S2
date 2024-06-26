using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonControllerGreen : MonoBehaviour
{
public SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public GameManager GameManager;

    //public KeyCode KeyToPress;

    bool activation = false;
    public bool legal = false;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        
    }

    void LateUpdate()
    {

        if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton16) || Gamepad.current.leftTrigger.wasPressedThisFrame)
        {
            theSR.sprite = pressedImage;
            if(legal==false)
            {
                GameManager.NoteMissed();
                Debug.Log("Green");
            }
        }

        if(Input.GetKeyUp(KeyCode.R) || Input.GetKeyUp(KeyCode.JoystickButton16) || Gamepad.current.leftTrigger.wasReleasedThisFrame)
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
}
