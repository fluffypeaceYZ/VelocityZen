using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
	float BottomScreen = 10f;
	float UpperScreen = -7.4f;
	public GameObject bullet;
	public GameObject shield;
	 
	// Use this for initialization
	void Start () {

		 

	}
	
	// Update is called once per frame
	void Update () {

		Physics.IgnoreCollision(bullet.GetComponent<Collider>(), shield.GetComponent<Collider>());

		transform.position += new Vector3(0, 0, 0.4f);




		if (Input.GetKey(KeyCode.UpArrow))

		{
			transform.position -= new Vector3(0.2f, 0, 0);
		}

		if (Input.GetKey(KeyCode.DownArrow))

		{
			transform.position += new Vector3(0.2f, 0, 0);
		}

		if (transform.position.x >= BottomScreen)

		{
			transform.position = new Vector3(BottomScreen, transform.position.y, transform.position.z);
		}

		else if (transform.position.x <= UpperScreen)

		{
			transform.position = new Vector3(UpperScreen, transform.position.y, transform.position.z);

		}
		
	}
}
