using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone1 : MonoBehaviour {

	public GameObject Player;
	public GameObject UFOprefab;
	public GameObject TriggerZone;
	//UFOHealth UFOScript;
	GameObject enemyUFOInstance;
	bool canCreateTriggerZone;

	// Use this for initialization
	void Start () {
		canCreateTriggerZone = false;
	}
	
	// Update is called once per frame
	void Update () {

		/*GameObject UFOLimit = GameObject.FindWithTag("UFO").GetComponent<UFOHealth>();

		if (UFOHealth.numberofUFOs == 0) {
		
			GameObject TriggerInstance;

		}*/
		if(enemyUFOInstance == null) {

			if(canCreateTriggerZone) {
				print ("Create new trigger zone");

				canCreateTriggerZone = false;

				GameObject TriggerInstance;
				TriggerInstance = Instantiate (TriggerZone, new Vector3 (9, -1.5f, Player.transform.position.z + 80), TriggerZone.transform.rotation) as GameObject;
			}

		}	 

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			print ("Collide");

			enemyUFOInstance =  Instantiate (UFOprefab, new Vector3 (Player.transform.position.x, Player.transform.position.y +14, Player.transform.position.z + 28), UFOprefab.transform.rotation) as GameObject;

			canCreateTriggerZone = true;

			//GameObject UFOLimit = GameObject.Find("UFO_Unity");

			 //UFOScript = enemyUFOInstance.GetComponent<UFOHealth>();


		}
	}
}
