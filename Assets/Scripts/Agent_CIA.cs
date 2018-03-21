using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Agent_CIA : MonoBehaviour {

	public Animation animation;
	public Sprite[] lifeRingArray;
	public Image lifeRing;
	private int lifeRingCount = 12;
	public GameObject lifeRingSpawnAgent;
	public GameObject lifeRingInstance;
	public Canvas canvas;
	public float AgentSpeed;

	// Use this for initialization
	void Start () {

		animation = gameObject.GetComponent<Animation>();
		
	}
	
	// Update is called once per frame
	void Update () {

		animation.Play("walkbackwards");

		transform.position = new Vector3(Mathf.PingPong (Time.time * AgentSpeed, 7) -11, transform.position.y ,transform.position.z);

		
		transform.position += new Vector3(0, 0, 0.4f);

		Vector3 lifeRingPos = Camera.main.WorldToScreenPoint (lifeRingSpawnAgent.transform.position);
		lifeRing.transform.position = lifeRingPos;

		if (Input.GetKeyDown (KeyCode.L)) {

			TakeDamage2 ();

		
		}
	}

	public void TakeDamage2()
	{
		if(lifeRingCount > 0) lifeRingCount-=2;

		//Ternary operator
		//lifeRingCount = (lifeRingCount > 0)? lifeRingCount--: 0;
		//lifeRingCount = (condition)? true value : false value;

		if (lifeRingCount == 0){

			lifeRing.sprite = lifeRingArray [0];
			Destroy (this.gameObject, 2); 
			Destroy (lifeRing, 1);
		}

		lifeRing.sprite = lifeRingArray [lifeRingCount];
	}

	void OnCollisionEnter (Collision col){

		if (col.gameObject.tag == "Bullet") {


			TakeDamage2 ();
		}


	}

}
