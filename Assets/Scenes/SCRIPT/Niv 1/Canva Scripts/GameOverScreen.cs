using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreTextMenu;
    public AudioSource SoundEnterMenu;
    public AudioSource SoundBackMenu;

    public GameObject GameOverCanva;
    
    public void Setup(int score)
    {
        GameOverCanva.SetActive(true);
        scoreTextMenu.text = score.ToString() + " Pts";
        Time.timeScale = 0f;
    }

    public void RestartButton()
    {
        GameOverCanva.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SoundEnterMenu.Play();
        Time.timeScale = 1f;
    }

    public void MenuButton()
    {
        GameOverCanva.SetActive(false);
        SceneManager.LoadScene("MainMenu");
        SoundBackMenu.Play();
        Time.timeScale = 1f;
    }

    public void quit()
    {
        Application.Quit();
    }
}
