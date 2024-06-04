using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
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

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Q) ||Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            theSR.sprite = pressedImage;
            if(legal==false)
            {
                GameManager.TakeDamage(1);
                GameManager.missSFX.Play();
            }
        }

        if(Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.JoystickButton4))
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
