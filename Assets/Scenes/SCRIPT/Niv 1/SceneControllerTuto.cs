using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControllerTuto : MonoBehaviour
{
    public static SceneControllerTuto instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    
    public void NextLevel()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
