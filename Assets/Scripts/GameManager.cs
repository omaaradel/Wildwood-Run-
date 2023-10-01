using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool bgSoundPlayed = false;
    public bool isPaused = false; 

    private bool dieSoundPlayed = false;
    private int buildIndex;
    private Enemytrap manager;
    private winning wonManager;
    private Enemyshoot enemyManager;
    private AudioManager audioManager;
    private switchcamera cameraManager;

    [SerializeField] GameObject pausemenus;
    void Start()
    {
        pausemenus.SetActive(false);
        manager = GameObject.Find("Player").GetComponent<Enemytrap>();
        wonManager = GameObject.Find("Chest Golden").GetComponent<winning>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        Scene currentScene = SceneManager.GetActiveScene();
        buildIndex = currentScene.buildIndex;
        if (buildIndex==5)
        {
            cameraManager = GameObject.Find("Square").GetComponent<switchcamera>();
            enemyManager = GameObject.Find("Final Boss").GetComponent<Enemyshoot>();
        }
    }

    void Update()
    {
        //pausing
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused && !manager.isdead && !wonManager.won)
        {
            pausemenus.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
        //cancelPausing
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused && !manager.isdead && !wonManager.won)
        {
            continueGameAfterPause();
        }
        if (buildIndex == 5)
        {
            if (enemyManager.currentHealth <= 0 && !dieSoundPlayed)
            {
                audioManager.playSFX(audioManager.enemyDie);
                dieSoundPlayed = true;
            }
            if (cameraManager.camera1working && audioManager.musicSource.clip == audioManager.battlefieldMusic)
            {
                audioManager.musicSource.clip = audioManager.backgroundMusic;
                audioManager.musicSource.Play();

            }
            if (!cameraManager.camera1working && audioManager.musicSource.clip == audioManager.backgroundMusic)
            {
                audioManager.musicSource.clip = audioManager.battlefieldMusic;
                audioManager.musicSource.Play();

            }
        }
       
    }
    public void continueGameAfterPause()
    {
        pausemenus.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    
}
