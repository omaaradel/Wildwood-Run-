using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winning : MonoBehaviour
{
	public GameObject wonpanel;
	public GameObject gemstext;
	private Collect manager;
	public bool won ;
	public AudioSource winsound;
	public int Gemsneeded;
	public int nextScene;
	// Start is called before the first frame update
	private void Start()
    {
		won = false;
		wonpanel.SetActive(false);
		manager = GameObject.Find("Player").GetComponent<Collect>();
		nextScene = SceneManager.GetActiveScene().buildIndex + 1;

	}
    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && manager.scoreSO.Value>=Gemsneeded)
		{
		    winsound.Play();
			wonpanel.SetActive(true);
			gemstext.SetActive(false);
			won = true;
			if (nextScene > PlayerPrefs.GetInt("levelAt"))
				{
				PlayerPrefs.SetInt("levelAt", nextScene);
                }
			Time.timeScale = 0;
			

		}
	}
}
