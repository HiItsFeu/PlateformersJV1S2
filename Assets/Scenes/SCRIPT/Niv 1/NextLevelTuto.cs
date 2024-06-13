using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelScriptTuto : MonoBehaviour
{
    public SceneControllerTuto SceneControllerTuto;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneControllerTuto.NextLevel();
        }
    }
}
