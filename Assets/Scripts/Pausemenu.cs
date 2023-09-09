using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{
    public GameObject pausemenus;
    private bool ispaused = false;
    void Start()
    {
        pausemenus.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !ispaused)
        {
            pausemenus.SetActive(true);
            Time.timeScale = 0;
            ispaused = true;
        }
    }
    public void continuegame()
    {
        pausemenus.SetActive(false);
        Time.timeScale = 1;
        ispaused = false;
    }
    
}
