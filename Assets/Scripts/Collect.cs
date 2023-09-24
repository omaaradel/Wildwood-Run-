using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//[RequireComponent(typeof(AudioSource))]
public class Collect : MonoBehaviour
{
	[SerializeField]
	private int score;
	[SerializeField]
	private TextMeshProUGUI scoretext;
	[SerializeField]
	private GameObject collectEffect;
	[SerializeField]
	private AudioSource collectsound;
	[SerializeField]
	private AudioSource wonsound;
	public int scoreAddedOneLevel;
	public FloatSO scoreSO;
	public int Gemsneeded;

	// Use this for initialization
	void Start()
	{
		score = 0; scoreAddedOneLevel= 0;
		scoretext.text = "Gems: " + scoreSO.Value;

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

		scoreSO.Value ++;
		scoreAddedOneLevel++;
		scoretext.text = "Gems: " + scoreSO.Value;
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
