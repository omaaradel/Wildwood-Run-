using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//[RequireComponent(typeof(AudioSource))]
public class Collect : MonoBehaviour
{
	public FloatSO scoreSO;
	public int scoreAddedOneLevel;
	public int gemsNeeded;

	private AudioManager audioManager;


	[SerializeField] TextMeshProUGUI scoreText;
	[SerializeField] GameObject collectEffect;

	

	// Use this for initialization
	void Start()
	{
		scoreAddedOneLevel= 0;
		scoreText.text = "Gems: " + scoreSO.Value;
		audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();

	}
   


    public void addscore()
	{

		scoreSO.Value ++;
		scoreAddedOneLevel++;
		scoreText.text = "Gems: " + scoreSO.Value;
		audioManager.playSFX(audioManager.playerCollect);

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
