using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVol")) { loadVolume(); }
        else { setMusicVolume(); }
        if (PlayerPrefs.HasKey("SFXVol")) { loadVolume(); }
        else { setSFXVolume(); }

    }   
    public void setMusicVolume()
    {
        float musicVolume = musicSlider.value;
        mixer.SetFloat("music",Mathf.Log10(musicVolume)*20);
        PlayerPrefs.SetFloat("musicVol", musicVolume);
    }
    public void setSFXVolume()
    {
        float SFXVolume = sfxSlider.value;
        mixer.SetFloat("SFX", Mathf.Log10(SFXVolume) * 20);
        PlayerPrefs.SetFloat("SFXVol", SFXVolume);
    }
    private void loadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVol");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVol");
        setMusicVolume();
        setSFXVolume();
    }
}
 