using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvaPauseMeny : MonoBehaviour
{
    
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameManager GameManager;
    
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Debug.Log("Paused");
                ResumeButton();
            }
            else
            {
                Pause();
            }
        }

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameManager.theMusic.Pause();
        GameIsPaused = true;
    }
    
    public void ResumeButton()
    {   
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameManager.theMusic.UnPause();
        GameIsPaused = false;
    }
    
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        GameManager.theMusic.Play();
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }
}
