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

    private float currentTime;
    private float currentTimeMainMusic;
    private float currentTimeChangeMusic;

    public AudioSource SoundBackMenu;
    public AudioSource SoundEnterMenu;
    
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton9))
        {
            if(GameIsPaused)
            {
                Debug.Log("Paused");
                ResumeButton();
                SoundBackMenu.Play();
            }
            else
            {
                Pause();
                SoundEnterMenu.Play();
            }
        }

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        if(!GameManager.theMusic.isPlaying)
        {
            currentTimeMainMusic = GameManager.MainMusic.time;
            GameManager.MainMusic.Stop();
        }
        if(GameManager.theMusic.isPlaying)
        {
            currentTime = GameManager.theMusic.time;
            GameManager.theMusic.Stop();
        }
        if(GameManager.ChangeMusic.isPlaying)
        {
            currentTimeChangeMusic = GameManager.ChangeMusic.time;
            GameManager.ChangeMusic.Stop();
        }
        GameIsPaused = true;
    }
    
    public void ResumeButton()
    {   
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SoundBackMenu.Play();
        if(GameManager.startPlaying)
        {
            if(!GameManager.theMusic.isPlaying)
            {
                GameManager.theMusic.Play();
                GameManager.theMusic.time = currentTime;
            }
        }
        if(!GameManager.theMusic.isPlaying)
        {
            if(!GameManager.ChangeMusic.isPlaying)
            {
                GameManager.MainMusic.Play();
                GameManager.MainMusic.time = currentTimeMainMusic;
            }
        }
        if(!GameManager.theMusic.isPlaying)
        {
            if(GameManager.MainMusic.isPlaying)
            {
                if(GameManager.ChangeMusic.isPlaying)
                {
                    GameManager.ChangeMusic.time = currentTimeChangeMusic;
                    GameManager.ChangeMusic.Play();

                    GameManager.MainMusic.Stop();
                    currentTime = GameManager.theMusic.time;
                }
            }
        }
        GameIsPaused = false;
    }
    
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        SoundEnterMenu.Play();
        if(GameManager.startPlaying)
        {
            GameManager.theMusic.Play();
        }
        if(!GameManager.startPlaying)
        {
            GameManager.MainMusic.Play();
        }
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        SoundBackMenu.Play();
    }
}
