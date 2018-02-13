using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOScript : MonoBehaviour {

	public float UFOSpeed;
	public GameObject laserSpawn;
	public GameObject laserInstance;
	public float Laser_Forward_Force;
	public float laserTimer;
	public AudioClip laser;
	AudioSource audioSource;



	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3(Mathf.PingPong (Time.time * UFOSpeed, 16) -8, transform.position.y ,transform.position.z);

		transform.position += new Vector3(0, 0, 0.4f);

		laserTimer -= Time.deltaTime;
		if (laserTimer <=0){

			laserTimer = 3;
		}
		 
		if (laserTimer >= 3){
		GameObject Temporary_Laser_Handler;
		Temporary_Laser_Handler = Instantiate(laserInstance,laserSpawn.transform.position,laserSpawn.transform.rotation) as GameObject;
		laserTimer = 3;

		
		//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
		//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
			Temporary_Laser_Handler.transform.Rotate(Vector3.left * 90);
			 
		//Retrieve the Rigidbody component from the instantiated Bullet and control it.
		Rigidbody Temporary_RigidBody;
		Temporary_RigidBody = Temporary_Laser_Handler.GetComponent<Rigidbody>();

		//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
		//Temporary_RigidBody.AddForce(transform.forward * Laser_Forward_Force);
			Temporary_RigidBody.AddForce(0, -8, -18, ForceMode.Impulse);
			audioSource.PlayOneShot(laser, 1);

		//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
			Destroy(Temporary_Laser_Handler, 4.0f);}


		
	}
}
