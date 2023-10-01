using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchcameraback : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject camera1;
    [SerializeField] private GameObject camera2;
    private switchcamera manager;
    private GameManager gameManager;

    private void Start()
    {
        manager = GameObject.Find("Square").GetComponent<switchcamera>();
        gameManager  = GameObject.Find("Game manager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cam1();
        }
    }
    public void cam1()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
        manager.camera1working = true;
        gameManager.bgSoundPlayed = false;
    }
   
}
