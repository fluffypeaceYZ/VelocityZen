using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone1 : MonoBehaviour {

	public GameObject Player;
	public GameObject UFOprefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			print ("Collide");
			GameObject enemyUFOInstance;
			enemyUFOInstance =  Instantiate (UFOprefab, new Vector3 (Player.transform.position.x, Player.transform.position.y +14, Player.transform.position.z + 28), UFOprefab.transform.rotation) as GameObject;
			 

		}
	}
}
