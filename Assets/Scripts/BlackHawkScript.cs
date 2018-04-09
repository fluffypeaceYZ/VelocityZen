using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHawkScript : MonoBehaviour {
	public GameObject bhbulletSpawnRight;
	public GameObject bhbulletSpawnLeft;
	public GameObject bhbulletInstance;
	public float bhbulletTimer = 0.4f;
	public float bhbulletSpend = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		bhbulletTimer -= Time.deltaTime;
		bhbulletSpend -= Time.deltaTime;
		if (bhbulletSpend <= 0) {
			bhbulletSpend = 10f;
		}

		transform.position += new Vector3(0, 0, 0.4f);

		if ((bhbulletSpend >=5f) && (bhbulletTimer <= 0)){


			GameObject Temporary_bhbulletRight_Handler;
			Temporary_bhbulletRight_Handler = Instantiate(bhbulletInstance,bhbulletSpawnRight.transform.position,bhbulletSpawnRight.transform.rotation) as GameObject;
			GameObject Temporary_bhbulletLeft_Handler;
			Temporary_bhbulletLeft_Handler = Instantiate(bhbulletInstance,bhbulletSpawnLeft.transform.position,bhbulletSpawnLeft.transform.rotation) as GameObject;
			bhbulletTimer  = 0.4f;

			Temporary_bhbulletRight_Handler.transform.Rotate(Vector3.left * 90);
			Temporary_bhbulletLeft_Handler.transform.Rotate(Vector3.left * 90);

			Rigidbody Temporary_RigidBodyRight;
			Temporary_RigidBodyRight = Temporary_bhbulletRight_Handler.GetComponent<Rigidbody>();

			Rigidbody Temporary_RigidBodyLeft;
			Temporary_RigidBodyLeft = Temporary_bhbulletLeft_Handler.GetComponent<Rigidbody>();

			Temporary_RigidBodyRight.AddForce(0, -8, -18, ForceMode.Impulse);
			Temporary_RigidBodyLeft.AddForce(0, -8, -18, ForceMode.Impulse);

			Destroy(Temporary_bhbulletRight_Handler, 4.0f);
			Destroy(Temporary_bhbulletLeft_Handler, 4.0f);


		}
		
	}
}
