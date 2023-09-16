using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winning : MonoBehaviour
{
	public GameObject wonpanel;
	public GameObject gemstext;
	private Collect manager;
	public bool won ;
	public AudioSource winsound;
	public int Gemsneeded;
	// Start is called before the first frame update
	private void Start()
    {
		won = false;
		wonpanel.SetActive(false);
		manager = GameObject.Find("Player").GetComponent<Collect>();
	}
    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && manager.score>=Gemsneeded)
		{
		    winsound.Play();
			wonpanel.SetActive(true);
			gemstext.SetActive(false);
			won = true;
			Time.timeScale = 0;
			

		}
	}
}
