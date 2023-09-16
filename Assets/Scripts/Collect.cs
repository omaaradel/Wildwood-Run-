using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//[RequireComponent(typeof(AudioSource))]
public class Collect : MonoBehaviour
{

	public int score;
	public TextMeshProUGUI scoretext;
	public GameObject collectEffect;
	public AudioSource collectsound;
	public AudioSource wonsound;

	// Use this for initialization
	void Start()
	{
		score = 0;
		scoretext.text = "Gems: " + score;

	}
   // private void FixedUpdate()
   // {
   //     if (manager.won)
   //     {
			//wonsound.Play();
   //     }
   // }


    public void addscore()
	{

		score += 1;
		scoretext.text = "Gems: " + score;
		collectsound.Play();

	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Gem"))
		{
			addscore();
			Destroy(collision.gameObject);
			Instantiate(collectEffect, collision.transform.position, Quaternion.identity);
		}
	}

	
		
	
}
