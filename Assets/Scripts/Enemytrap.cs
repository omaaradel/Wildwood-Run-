using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemytrap : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isdead = false;
    public GameObject gameovertm;
    public GameObject gemstm;
    private Fox_Move manager;
    private winning wonmanager;
    private Collect managerCollect;
    public AudioSource killsound;
    public FloatSO scoreSO;
    private void Start()
    {
        gameovertm.SetActive(false);
        gemstm.SetActive(true);
        manager = GameObject.Find("Player").GetComponent<Fox_Move>();
        managerCollect = GameObject.Find("Player").GetComponent<Collect>();
        wonmanager = GameObject.Find("Chest Golden").GetComponent<winning>();
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
                killsound.Play();

            }
            else { Game0ver(); }
        }
        
    }
    void Game0ver()
    {
        if (!wonmanager.won)
        {
            isdead = true;
            scoreSO.Value -= managerCollect.scoreAddedOneLevel;

            gameovertm.SetActive(true);
            gemstm.SetActive(false);
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
