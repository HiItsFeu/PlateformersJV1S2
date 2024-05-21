using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonControllerYellow : MonoBehaviour
{
public SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public GameManager GameManager;

    //public KeyCode KeyToPress;

    bool activation = false;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E) ||Input.GetKeyDown(KeyCode.JoystickButton15) || Gamepad.current.leftTrigger.wasPressedThisFrame)
        {
            theSR.sprite = pressedImage;
        }

        if(Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.JoystickButton15) || Gamepad.current.leftTrigger.wasReleasedThisFrame)
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
