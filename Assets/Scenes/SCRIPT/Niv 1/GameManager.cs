using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public HealthBar healthBar;

    public HealthBarMob healthBarMob;

    public GameOverScreen GameOverScreen;

    public PlayerMovement Mouvement;

    public DestroyEnemy DestroyEnemy;

    public NoteObject NoteObject;

    public CanvaManager CanvaManagerHealth;
    public SpriteManager SpriteManagerGuitar;
    public CanvaHealthmobManager CanvaHealthmobManager;
    public CanvaScoreManager CanvaScoreManager;
    
    public ButtonController ButtonController;
    public ButtonControllerRed ButtonControllerRed;
    public ButtonControllerYellow ButtonControllerYellow;
    public ButtonControllerGreen ButtonControllerGreen;

    public CanvaPauseMeny CanvaPauseMenu;

    public int maxHealth = 10;
    public int currentHealth;
    
    public int maxHealthMob = 2;
    public int currentHealthMob;

    public int currentScore;
    public int scorePerNote = 100;
    public int ScorePerGoodNote = 125;
    public int ScorePerfectNote = 200;
    public int ScoreHitPerNote = 1;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public int currentHit;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiText;
    public TextMeshProUGUI hitText;

    public AudioSource hitSFX;
    public AudioSource missSFX;
    public AudioClip[] soundsMiss;
    public AudioClip[] soundsHit;

    public bool gameHasEnded=false;
    

    void Start()
    {
        instance = this;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentHealthMob = maxHealthMob;
        healthBarMob.SetMaxHealthMob(maxHealthMob);

        scoreText.text = "Score: 0";

        hitText.text = "Hits: 0";

        currentMultiplier = 1;
        currentHit = 0;

    }

    public void Update()
    {
        if(!startPlaying)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                startPlaying=true;
                theBS.hasStarted = true;
                Mouvement.CanMoove = false;
                CanvaManagerHealth.Activation();

                SpriteManagerGuitar.Activation();

                CanvaScoreManager.Activation();

                CanvaHealthmobManager.Activation();

                ButtonController.Activation();

                ButtonControllerRed.Activation();

                ButtonControllerYellow.Activation();

                ButtonControllerGreen.Activation();

                theMusic.Play();


            }

            //if (CanvaPauseMenu.GameIsPaused)
            //{
                //theMusic.Stop();
            //}

        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            theMusic.Stop();
        }
    }
    public void NoteHit()
    {
        
        hitSFX.clip=soundsHit[Random.Range(0,soundsHit.Length)];
        hitSFX.Play();

        Debug.Log("Hit On Time");

            if(currentMultiplier - 1 < multiplierThresholds.Length)
            {
                multiplierTracker++;

                if(multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
                {
                    multiplierTracker = 0;
                    currentMultiplier++;
                }

            }
        
        multiText.text = "Multiplier: x" + currentMultiplier;

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
        
        currentHit += ScoreHitPerNote;
        hitText.text = "Hits: " + currentHit;
    }

    public void NoteMissed()
    {
        TakeDamage(1);

        missSFX.clip=soundsMiss[Random.Range(0,soundsMiss.Length)];
        missSFX.Play();

        Debug.Log("Missed Note");
        
        currentMultiplier = 1;
        multiplierTracker = 0;
        currentHit = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;
        hitText.text = "Hits: " + currentHit;
    }
    
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        
        if(currentHealth <= 0)
        {
            GameOver();
            theMusic.Stop();
        }
    }

    public void DealDamageToMob (int damageMob)
    {
        currentHealthMob -= damageMob;

        healthBarMob.SetHealthMob(currentHealthMob);

        if(currentHealthMob <= 0)
        {
            GameWin();
        }
    }

    void GameOver()
    {
        if (gameHasEnded==false)
        {
            gameHasEnded = true;
            GameOverScreen.Setup(currentScore);
            Debug.Log("Game Over");
        }
        
    }
    
    public void SpecialNotes()
    {
        Debug.Log("Damage");
        DealDamageToMob(1);
    }

    public void SpecialNoteMissed()
    {
        TakeDamage(1);

        missSFX.clip=soundsMiss[Random.Range(0,soundsMiss.Length)];
        missSFX.Play();

        Debug.Log("Missed Note");
        
        currentMultiplier = 1;
        multiplierTracker = 0;
        currentHit = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;
        hitText.text = "Hits: " + currentHit;
    }

    public void GameWin()
    {
        gameHasEnded = true;
        Mouvement.CanMoove = true;
        Debug.Log("Game Win");

        DestroyEnemy.DestroyGameObject();

        CanvaManagerHealth.Unactivated();

        SpriteManagerGuitar.Unactivated();

        CanvaHealthmobManager.Unactivated();

        CanvaScoreManager.Unactivated();

        ButtonController.Unactivated();

        ButtonControllerRed.Unactivated();

        ButtonControllerYellow.Unactivated();

        ButtonControllerGreen.Unactivated();
    }

    

}
