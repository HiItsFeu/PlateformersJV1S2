using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerMob1 : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManagerMob1 instance;

    public GameOverScreen GameOverScreen;

    public PlayerMovement Mouvement;

    public DestroyEnemy DestroyEnemy;

    public NoteObject NoteObject;

    public Transform DuelPlayerPos;

    public Transform Target;

    public SpriteManager SpriteManagerGuitar;
    public SpriteManagerAmpli SpriteManagerAmpli;
    public SpriteManagerManche SpriteManagerManche;
    
    public ButtonController ButtonController;
    public ButtonControllerRed ButtonControllerRed;
    public ButtonControllerYellow ButtonControllerYellow;
    public ButtonControllerGreen ButtonControllerGreen;

    public CanvaPauseMeny CanvaPauseMenu;
    
    public int maxHealthMob = 1;
    public int currentHealthMob;

    public AudioSource hitSFX;
    public AudioSource missSFX;
    
    public AudioSource SoundDuelWin;
    public AudioSource SoundDuelLoosed;
    public AudioSource SoundTheDuelStart;
    
    public AudioClip[] soundsMiss;
    public AudioClip[] soundsHit;

    public bool gameHasEnded=false;
    

    void Start()
    {
        instance = this;

        currentHealthMob = maxHealthMob;

    }

    public void Update()
    {
        if(!startPlaying)
        {
            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                startPlaying=true;
                theBS.hasStarted = true;
                Mouvement.CanMoove = false;

                SpriteManagerGuitar.Activation();

                ButtonController.Activation();

                ButtonControllerRed.Activation();

                ButtonControllerYellow.Activation();

                ButtonControllerGreen.Activation();

                SpriteManagerAmpli.ActivationAmpli();

                SpriteManagerManche.Activation();

                transform.position = DuelPlayerPos.position;

                Target.position = DuelPlayerPos.position;
                
                SoundTheDuelStart.Play();
                
                theMusic.Play();


            }

        }
    }
    public void NoteHit()
    {
        
        hitSFX.clip=soundsHit[Random.Range(0,soundsHit.Length)];
        hitSFX.Play();
    }

    public void NoteMissed()
    {
        missSFX.clip=soundsMiss[Random.Range(0,soundsMiss.Length)];
        missSFX.Play();
    }

    public void DealDamageToMob (int damageMob)
    {
        currentHealthMob -= damageMob;

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
            GameOverScreen.gameObject.SetActive(true);
            Debug.Log("Game Over");
            SoundDuelLoosed.Play();
        }
        
    }
    
    public void SpecialNotes()
    {
        Debug.Log("Damage");
        DealDamageToMob(1);
    }

    public void SpecialNoteMissed()
    {
        missSFX.clip=soundsMiss[Random.Range(0,soundsMiss.Length)];
        missSFX.Play();
    }

    public void GameWin()
    {
        gameHasEnded = true;
        Mouvement.CanMoove = true;
        Debug.Log("Game Win");
        theMusic.Stop();
        SoundDuelWin.Play();

        DestroyEnemy.DestroyGameObject();

        SpriteManagerGuitar.Unactivated();

        ButtonController.Unactivated();

        ButtonControllerRed.Unactivated();

        ButtonControllerYellow.Unactivated();

        ButtonControllerGreen.Unactivated();

        SpriteManagerManche.Unactivated();

    }

    

}
