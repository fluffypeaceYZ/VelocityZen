using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone1 : MonoBehaviour {

	public GameObject Player;
	public GameObject UFOprefab;
	public GameObject TriggerZone;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		/*GameObject UFOLimit = GameObject.FindWithTag("UFO").GetComponent<UFOHealth>();

		if (UFOHealth.numberofUFOs == 0) {
		
			GameObject TriggerInstance;

		}*/

		GameObject UFO = GameObject.Find("UFO_Unity");
		UFOHealth UFOScript = UFO.GetComponent<UFOHealth>();
	
		if(UFOScript.numberofUFOs == 0) {




		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			print ("Collide");
			GameObject enemyUFOInstance;
			enemyUFOInstance =  Instantiate (UFOprefab, new Vector3 (Player.transform.position.x, Player.transform.position.y +14, Player.transform.position.z + 28), UFOprefab.transform.rotation) as GameObject;
			 

		}
	}
}
