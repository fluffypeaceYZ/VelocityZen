using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float CannonSpeed;
	public GameObject bulletSpawn;
	public GameObject bulletInstance;
	public float Bullet_Forward_Force;
	public float bulletTimer;
	public float minAngle, maxAngle;

	// Use this for initialization
	void Start () {
	
	}

	Quaternion ClampRotationAroundXAxis(Quaternion q, float min, float max)

{
		q.x /= q.w;
		q.y /= q.w;
		q.z /= q.w;
		q.w = 1.0f;

		float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
		angleX = Mathf.Clamp(angleX, min, max);
		q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
		return q;
	}
	
	// Update is called once per frame
	void Update () {

	transform.rotation = ClampRotationAroundXAxis(transform.rotation, minAngle, maxAngle);

		if (Input.GetKey (KeyCode.Q)) 

		{
			transform.Rotate(Vector3.left * Time.deltaTime * CannonSpeed);
		}






		if (Input.GetKey (KeyCode.A))

		{
			transform.Rotate(Vector3.right * Time.deltaTime * CannonSpeed);
		}



		bulletTimer -= Time.deltaTime;
		if (bulletTimer <=0){

			bulletTimer = 0;
		}
	
		if (Input.GetKey(KeyCode.Tab) && bulletTimer == 0)
			
		{
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
 