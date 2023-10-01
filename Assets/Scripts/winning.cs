using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winning : MonoBehaviour
{
	public bool won;
	private int nextScene;

	private AudioManager audioManager;
	private StarManager starManage;

	[SerializeField] GameObject wonMenu;
	[SerializeField] GameObject gemstext;
	
	
	// Start is called before the first frame update
	private void Start()
    {
		won = false;
		wonMenu.SetActive(false);
		starManage = GameObject.Find("Canvas").GetComponent<StarManager>();
		audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
		nextScene = SceneManager.GetActiveScene().buildIndex + 1;

	}
    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			audioManager.playSFX(audioManager.playerWin);
			wonMenu.SetActive(true);
			gemstext.SetActive(false);
			won = true;
			starManage.showStars(3);
			if (nextScene > PlayerPrefs.GetInt("levelAt"))
				{
				PlayerPrefs.SetInt("levelAt", nextScene);
                }
			

		}
	}
}
