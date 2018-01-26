using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOScript : MonoBehaviour {

	public float UFOSpeed;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3(Mathf.PingPong (Time.time * UFOSpeed, 16) -8, transform.position.y ,transform.position.z);

		transform.position += new Vector3(0, 0, 0.4f);
		
	}
}
