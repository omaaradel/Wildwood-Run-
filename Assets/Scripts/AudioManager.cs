using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource SFXSource;

    public AudioClip backgroundMusic;
    public AudioClip battlefieldMusic;
    public AudioClip playerCollect;
    public AudioClip playerJump;
    public AudioClip playerDie;
    public AudioClip playerPunch;
    public AudioClip playerKill;
    public AudioClip playerShoot;
    public AudioClip playerWin;
    public AudioClip enemyShoot;
    public AudioClip enemyDie;


    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }
   
    public void playSFX(AudioClip clips)
    {
        SFXSource.PlayOneShot(clips);
    }
    
    public void playmusic(AudioClip clips)
    {
        musicSource.PlayOneShot(clips);
    }
}
