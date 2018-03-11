using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
	public GameObject Road;
	public GameObject Fence;
	public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "Player") {
			print ("New Background");
			GameObject roadInstance;
			roadInstance = Instantiate (Road, new Vector3 (0, 0, Player.transform.position.z + 1452.5f), Road.transform.rotation) as GameObject;
			GameObject fenceInstance;
			fenceInstance = Instantiate (Fence, new Vector3 (Fence.transform.position.x, Fence.transform.position.y, Player.transform.position.z + 1460), Fence.transform.rotation) as GameObject;
			 
		}
	}

}
