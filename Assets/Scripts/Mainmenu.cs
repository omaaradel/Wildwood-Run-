using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI instructionsText;
    [SerializeField] GameObject pressSText;
    private void Awake()
    {
#if UNITY_ANDROID
        instructionsText.text = "Move: <-> Joystick"+ "\nJump: ↑ Button" + "\nCrouch: ↓ Button" + "\nAttack: X Button";
        pressSText.SetActive(false);
        
#else
        instructionsText.text = "Move: <-> Arrow keys" + "\nJump: Space" + "\nCrouch: ↓ Arrow" + "\nAttack: C";
        pressSText.SetActive(true);
#endif

    }
    public void playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;

    }
    public void quitgame()
    {

        PlayerPrefs.DeleteAll();
        Application.Quit();
    }   
}
