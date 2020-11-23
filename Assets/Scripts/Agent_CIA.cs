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
	public GameObject agentBulletSpawn;
	public GameObject agentBulletInstance;
	public float agentBullet_Forward_Force;
	public float agentBulletTimer;
	public AudioClip AgentBullet;
	AudioSource audioSource;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource>();
		animation = gameObject.GetComponent<Animation>();
		
	}



	// Update is called once per frame
	void Update () {

		if (lifeRingCount <= 2) {

			rb.isKinematic = false; 
			rb.detectCollisions = true;

		}



		//animation.Play("walkbackwards");

		transform.position = new Vector3(Mathf.PingPong (Time.time * AgentSpeed, 8) -8, transform.position.y ,transform.position.z);

		
		transform.position += new Vector3(0, 0, 0.1f);

		Vector3 lifeRingPos = Camera.main.WorldToScreenPoint (lifeRingSpawnAgent.transform.position);
		lifeRing.transform.position = lifeRingPos;

		/*if (Input.GetKeyDown (KeyCode.L)) {

			TakeDamage2 ();

		
		}*/

		agentBulletTimer -= Time.deltaTime;
		 


		if (agentBulletTimer <= 0){
			GameObject Temporary_AgentBullet_Handler;
			Temporary_AgentBullet_Handler = Instantiate(agentBulletInstance,agentBulletSpawn.transform.position,agentBulletSpawn.transform.rotation) as GameObject;
			agentBulletTimer = Random.Range (4, 1);


			//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
			//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
			Temporary_AgentBullet_Handler.transform.Rotate(Vector3.left * 90);

			//Retrieve the Rigidbody component from the instantiated Bullet and control it.
			Rigidbody Temporary_RigidBody;
			Temporary_RigidBody = Temporary_AgentBullet_Handler.GetComponent<Rigidbody>();

			//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
			//Temporary_RigidBody.AddForce(transform.forward * Laser_Forward_Force);
			Temporary_RigidBody.AddForce(0, -3, -13, ForceMode.Impulse);
			audioSource.PlayOneShot(AgentBullet, 1);

			//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
			Destroy(Temporary_AgentBullet_Handler, 4.0f);}


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
