using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulleSlash : MonoBehaviour
{
    public GameManager GManager;
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown(KeyCode.JoystickButton3))
        if(GManager.startPlaying==true)
        {
            Destroy(gameObject);
        }
    }
}
