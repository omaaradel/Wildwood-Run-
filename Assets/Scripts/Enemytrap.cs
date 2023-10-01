using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemytrap : MonoBehaviour
{
    public bool isdead = false;
    public FloatSO scoreSO;

    private Fox_Move manager;
    private winning wonManager;
    private AudioManager audioManager;
    private Collect managerCollect;

    [SerializeField] GameObject gameoverMenu;
    [SerializeField] GameObject gemsText;

    private void Start()
    {
        gameoverMenu.SetActive(false);
        gemsText.SetActive(true);
        manager = GameObject.Find("Player").GetComponent<Fox_Move>();
        managerCollect = GameObject.Find("Player").GetComponent<Collect>();
        wonManager = GameObject.Find("Chest Golden").GetComponent<winning>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
    }
    private void Update()
    {
        if (transform.position.y < -25) { Game0ver(); }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") )
        {
            if (manager.attacking)
            {
                Destroy(collision.gameObject);
                audioManager.playSFX(audioManager.playerKill);

            }
            else { Game0ver(); }
        }
        
    }

    void Game0ver()
    {
        audioManager.playSFX(audioManager.playerDie);
        if (!wonManager.won)
        {
            isdead = true;
            scoreSO.Value -= managerCollect.scoreAddedOneLevel;

            gameoverMenu.SetActive(true);
            gemsText.SetActive(false);
        }


    }
    public void restartlevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void backmainmenus()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
