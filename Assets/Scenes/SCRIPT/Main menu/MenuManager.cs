using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void TutoButton()
    {
        SceneManager.LoadScene("Tutorial");
    }
    
    public void Level1Button()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Level2Button()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3Button()
    {
        SceneManager.LoadScene("Level3");
    }

    public void BossLevelButton()
    {
        SceneManager.LoadScene("BossLevel");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
