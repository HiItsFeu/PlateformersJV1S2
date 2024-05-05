using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerGreen : MonoBehaviour
{
public SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public GameManager GameManager;

    public KeyCode KeyToPress;

    bool activation = false;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyToPress))
        {
            theSR.sprite = pressedImage;
        }

        if(Input.GetKeyUp(KeyToPress))
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
