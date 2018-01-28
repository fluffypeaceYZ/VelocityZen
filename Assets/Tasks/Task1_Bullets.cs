using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1_Bullets : MonoBehaviour {
	public float CannonSpeed;
	public GameObject bulletSpawn;
	public GameObject bulletInstance;
	public float Bullet_Forward_Force;
	public float bulletTimer;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Q)) 

		{
			transform.Rotate(Vector3.left * Time.deltaTime * CannonSpeed);
		}


		//These two bits of Code make the canon rotate. I need the canon to stop rotating at approximately a 90 degree angle facing forward, up and down.
		//See last bit of code for second issue.



		if (Input.GetKey (KeyCode.A))

		{
			transform.Rotate(Vector3.right * Time.deltaTime * CannonSpeed);
		}



		bulletTimer -= Time.deltaTime;
		if (bulletTimer <=0){

			bulletTimer = 0;
		}

		if (Input.GetKey(KeyCode.Tab) && bulletTimer == 0)

		{   //This is from a tutorial, sadly the bullets go backwards and do not follow the rotation of the canon.
			GameObject Temporary_Bullet_Handler;
			Temporary_Bullet_Handler = Instantiate(bulletInstance,bulletSpawn.transform.position,bulletSpawn.transform.rotation) as GameObject;
			bulletTimer = 0.2f;
			//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
			//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
			Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

			//Retrieve the Rigidbody component from the instantiated Bullet and control it.
			Rigidbody Temporary_RigidBody;
			Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

			//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
			Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

			//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
			Destroy(Temporary_Bullet_Handler, 4.0f);

		}

	}
}

