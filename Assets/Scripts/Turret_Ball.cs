using UnityEngine;
using System.Collections;

public class Turret_Ball : MonoBehaviour {

	public float CannonSpeed;
	private int AngleYUp = 90;
	private int AngleYDown = -90;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Q)) 
		
		{
			transform.Rotate(Vector3.left * Time.deltaTime * CannonSpeed);
		}


		 
	 


		if (Input.GetKey (KeyCode.A))
		
		{
			transform.Rotate(Vector3.right * Time.deltaTime * CannonSpeed);
		}



	}
}
