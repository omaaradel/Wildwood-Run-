using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//[RequireComponent(typeof(AudioSource))]
public class Rotate : MonoBehaviour
{

	[SerializeField] bool rotate;
	[SerializeField] float rotationSpeed;



	// Update is called once per frame
	void Update()
	{

		if (rotate)
			transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.World);

	}
}
	
