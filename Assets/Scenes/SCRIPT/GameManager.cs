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
    //public CharacterMouvement Mouvement;

    public int maxHealth = 10;
    public int currentHealth;
    
    public int maxHealthMob = 5;
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

    void Update()
    {
        if(!startPlaying)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                startPlaying=true;
                theBS.hasStarted = true;
                //Mouvement.CanMoove = false;

                theMusic.Play();
            }
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
    
    public void SpecialNotes ()
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

    void GameWin()
    {
        //Mouvement.CanMoove = true;
        Debug.Log("Game Win");
    }

}
