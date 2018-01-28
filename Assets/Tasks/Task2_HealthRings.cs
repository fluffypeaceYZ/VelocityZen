using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task2_HealthRings : MonoBehaviour {
	public Sprite[] lifeRingArray;
	public Image lifeRing;
	private int lifeRingCount = 12;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		//this makes the ring follow the player, I need a ring image instantiated on every prefab that I put on the map
		Vector3 lifeRingPos = Camera.main.WorldToScreenPoint (this.transform.position);
		lifeRing.transform.position = lifeRingPos;

		if (Input.GetKeyDown (KeyCode.R)) {

			TakeDamage ();

		}



	}
	//this is the code that makes the rings go down in Health
	public void TakeDamage()
	{
		lifeRingCount--;

		if (lifeRingCount <= 0){

			lifeRing.sprite = lifeRingArray [0];
			Destroy (this.gameObject, 1); 
			Destroy (lifeRing, 1);
		}

		lifeRing.sprite = lifeRingArray [lifeRingCount];
	}


	void OnCollisionEnter (Collision col){

		if (col.gameObject.tag == "Bullet") {

			TakeDamage ();
		}


	}
}

