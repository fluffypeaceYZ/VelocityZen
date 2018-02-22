using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFOHealth : MonoBehaviour {
	
	public Sprite[] lifeRingArray;
	public Image lifeRing;
	private int lifeRingCount = 12;
	public GameObject lifeRingSpawn;
	public GameObject lifeRingInstance;
	public Canvas canvas;
	// Use this for initialization
	void Start () {
		


		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 lifeRingPos = Camera.main.WorldToScreenPoint (lifeRingSpawn.transform.position);
		lifeRing.transform.position = lifeRingPos;

		if (Input.GetKeyDown (KeyCode.R)) {
		
			TakeDamage ();
		
		}



	}

	public void TakeDamage()
	{
		if(lifeRingCount > 0) lifeRingCount--;

		//Ternary operator
		//lifeRingCount = (lifeRingCount > 0)? lifeRingCount--: 0;
		//lifeRingCount = (condition)? true value : false value;

		if (lifeRingCount == 0){

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

