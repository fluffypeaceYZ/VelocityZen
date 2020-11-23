using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Bullet : MonoBehaviour {
	public float CannonSpeed;
	public GameObject bulletSpawn;
	public GameObject bulletInstance;
	public float Bullet_Forward_Force;
	private float bulletTimer;
	public float minAngle, maxAngle;
	public AudioClip impact;
	AudioSource audioSource;
	public Slider bulletSlider;



	// Use this for initialization
	void Start () {

		bulletTimer = 0f;

		audioSource = GetComponent<AudioSource>();

	
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

		if (Input.GetKey (KeyCode.Q) || (Input.GetAxis("CannonRight") < 0) || (bulletSlider.value < 0.5)) 

		{
			transform.Rotate(Vector3.left * Time.deltaTime * CannonSpeed);
		}






		if (Input.GetKey (KeyCode.A) || (Input.GetAxis("CannonRight") > 0) || (bulletSlider.value > 0.5))

		{
			transform.Rotate(Vector3.right * Time.deltaTime * CannonSpeed);
		}


	bulletTimer -= Time.deltaTime;

		if (bulletTimer <= 0f) {

			bulletTimer = 0f;
			 
			}

	
		if (Input.GetKey(KeyCode.Tab) && (bulletTimer == 0f) || (Input.GetKey (KeyCode.JoystickButton5) || (Input.GetAxis("RightTrigger") > 0)) && (bulletTimer == 0f))
			
		{
			GameObject Temporary_Bullet_Handler;
			Temporary_Bullet_Handler = Instantiate(bulletInstance,bulletSpawn.transform.position,bulletSpawn.transform.rotation) as GameObject;
			audioSource.PlayOneShot(impact, 1);
			bulletTimer = 0.5f;

			//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
			//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
			Temporary_Bullet_Handler.transform.Rotate(Vector3.right * 90);

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
 