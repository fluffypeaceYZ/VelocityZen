using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
	public GameObject Road;
	public GameObject Fence;
	public GameObject Player;
	 

	// Use this for initialization

	 
	void Start()
	{

		 

<<<<<<< HEAD
	}



		// Update is called once per frame
	void Update()
	{

			 

	}

		 

		void OnTriggerEnter(Collider other) {

			if (other.gameObject.tag == "Player") {
				print ("New Background");
				GameObject roadInstance;
				roadInstance = Instantiate (Road, new Vector3 (0, 0, Player.transform.position.z + 1452.6f), Road.transform.rotation) as GameObject;
				GameObject fenceInstance;
				fenceInstance = Instantiate (Fence, new Vector3 (-13, 3, Player.transform.position.z + 1461.6f), Fence.transform.rotation) as GameObject;

			}
		}
	
=======
		if (other.gameObject.tag == "Player") {
			print ("New Background");
			GameObject roadInstance;
			roadInstance = Instantiate (Road, new Vector3 (0, 0, Player.transform.position.z + 10), Road.transform.rotation) as GameObject;
			GameObject fenceInstance;
			fenceInstance = Instantiate (Fence, new Vector3 (-13, 3, Player.transform.position.z + 1461.6f), Fence.transform.rotation) as GameObject;
			 
		}
	}
>>>>>>> master

}
