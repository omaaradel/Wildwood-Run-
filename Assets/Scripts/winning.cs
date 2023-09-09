using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winning : MonoBehaviour
{
	public GameObject wonpanel;
	public GameObject gems;
	private Collect manager;
	public bool won ;
	public AudioSource winsound;
	// Start is called before the first frame update
	private void Start()
    {
		won = false;
		wonpanel.SetActive(false);
		manager = GameObject.Find("Player").GetComponent<Collect>();
	}
    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && manager.score>=1)
		{
			//if (gameObject != null) winsound.Play();
			Destroy(gameObject);
			wonpanel.SetActive(true);
			gems.SetActive(false);
			won = true;
			Time.timeScale = 0;
			

		}
	}
}
