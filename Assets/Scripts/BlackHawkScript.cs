using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackHawkScript : MonoBehaviour {
	public GameObject bhbulletSpawnRight;
	public GameObject bhbulletSpawnLeft;
	public GameObject bhbulletInstance;
	public GameObject bhrocketSpawn;
	public GameObject bhrocketInstance;
	public float bhbulletTimer = 0.8f;
	public float bhbulletSpend = 10f;
	public Sprite[] lifeRingArray;
	public Image lifeRing;
	private int lifeRingCount = 36;
	public GameObject lifeRingSpawnAgent;
	public GameObject lifeRingInstance;
	public AudioClip bhbullet;
	public AudioClip bhrocket;
	AudioSource audioSource;
	public ParticleSystem explosiongrey;
	public AudioClip BHExplosion;
	public AudioClip heliSound;
	private bool createdRocket = false;
	public float GameOverTimer = 2.99f;

	// Use this for initialization
	void Start () {

		audioSource = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {



		if (lifeRingCount <= 0) {

			GameOverTimer -= Time.deltaTime;
		}

	

		if (GameOverTimer <= 0) {

			SceneManager.LoadScene ("GameCompleted");


		}


		Vector3 lifeRingPos = Camera.main.WorldToScreenPoint (lifeRingSpawnAgent.transform.position);
		lifeRing.transform.position = lifeRingPos;

		bhbulletTimer -= Time.deltaTime;
		bhbulletSpend -= Time.deltaTime;
	 
		if (bhbulletSpend <= 0) {
			bhbulletSpend = 10f;
		}

		transform.position += new Vector3(0, 0, 0.4f);

		if ((bhbulletSpend >=6f) && (bhbulletTimer <= 0)){


			GameObject Temporary_bhbulletRight_Handler;
			Temporary_bhbulletRight_Handler = Instantiate(bhbulletInstance,bhbulletSpawnRight.transform.position,bhbulletSpawnRight.transform.rotation) as GameObject;
			GameObject Temporary_bhbulletLeft_Handler;
			Temporary_bhbulletLeft_Handler = Instantiate(bhbulletInstance,bhbulletSpawnLeft.transform.position,bhbulletSpawnLeft.transform.rotation) as GameObject;
			bhbulletTimer  = 0.8f;
			audioSource.PlayOneShot(bhbullet, 1);

			Temporary_bhbulletRight_Handler.transform.Rotate(Vector3.left * 90);
			Temporary_bhbulletLeft_Handler.transform.Rotate(Vector3.left * 90);

			Rigidbody Temporary_RigidBodyRight;
			Temporary_RigidBodyRight = Temporary_bhbulletRight_Handler.GetComponent<Rigidbody>();

			Rigidbody Temporary_RigidBodyLeft;
			Temporary_RigidBodyLeft = Temporary_bhbulletLeft_Handler.GetComponent<Rigidbody>();

			Temporary_RigidBodyRight.AddForce(0, -4, -18, ForceMode.Impulse);
			Temporary_RigidBodyLeft.AddForce(0, -4, -18, ForceMode.Impulse);

			Destroy(Temporary_bhbulletRight_Handler, 4.0f);
			Destroy(Temporary_bhbulletLeft_Handler, 4.0f);


		}

		if ((bhbulletSpend <= 3f) && (createdRocket == false)){
			GameObject Temporary_bhrocket_Handler;
			Temporary_bhrocket_Handler = Instantiate(bhrocketInstance,bhrocketSpawn.transform.position,bhrocketSpawn.transform.rotation) as GameObject;
			createdRocket = true;
			audioSource.PlayOneShot(bhrocket, 1);
			Temporary_bhrocket_Handler.transform.Rotate(Vector3.left * 360);

			Rigidbody Temporary_RigidBodyRocket;
			Temporary_RigidBodyRocket = Temporary_bhrocket_Handler.GetComponent<Rigidbody>();

			Temporary_RigidBodyRocket.AddForce(0, -6, -32, ForceMode.Impulse);

			Destroy(Temporary_bhrocket_Handler, 4.0f);

		
		}

		if (bhbulletSpend >= 3f) {
			createdRocket = false;}
		
	}

	public void TakeDamageBH()
	{

		lifeRingCount-=1;

		if (lifeRingCount == 36) {
			lifeRing.sprite = lifeRingArray [12];
		}
		if (lifeRingCount == 33) {
			lifeRing.sprite = lifeRingArray [11];
		}
		if (lifeRingCount == 30) {
			lifeRing.sprite = lifeRingArray [10];
		}
		if (lifeRingCount == 27) {
			lifeRing.sprite = lifeRingArray [9];
		}
		if (lifeRingCount == 24) {
			lifeRing.sprite = lifeRingArray [8];
		}
		if (lifeRingCount == 21) {
			lifeRing.sprite = lifeRingArray [7];
		}
		if (lifeRingCount == 18) {
			lifeRing.sprite = lifeRingArray [6];
		}
		if (lifeRingCount == 15) {
			lifeRing.sprite = lifeRingArray [5];
		}
		if (lifeRingCount == 12) {
			lifeRing.sprite = lifeRingArray [4];
		}
		if (lifeRingCount == 9) {
			lifeRing.sprite = lifeRingArray [3];
		}
		if (lifeRingCount == 6) {
			lifeRing.sprite = lifeRingArray [2];
		}
		if (lifeRingCount == 3) {
			lifeRing.sprite = lifeRingArray [1];
		}
		//Ternary operator
		//lifeRingCount = (lifeRingCount > 0)? lifeRingCount--: 0;
		//lifeRingCount = (condition)? true value : false value;

		if (lifeRingCount <= 0){

			 lifeRing.sprite = lifeRingArray [0];
			explosiongrey.Play ();
			audioSource.PlayOneShot(BHExplosion, 0.5f);
			Destroy (this.gameObject, 3); 
			Destroy (lifeRing, 1);


		}



	}

	void OnCollisionEnter (Collision col){

		if (col.gameObject.tag == "Bullet") {


			TakeDamageBH ();
		}

	}


}
