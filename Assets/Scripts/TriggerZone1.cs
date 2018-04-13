using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone1 : MonoBehaviour {

	public GameObject Player;
	public GameObject UFOprefab;
	public GameObject TriggerZone;
	public GameObject ciaAgent;
	public GameObject downciaAgent;
	public GameObject blackHawk;
	GameObject ciaAgentInstanceUP;
	GameObject ciaAgentInstanceDOWN;
	GameObject enemyUFOInstance;
	GameObject bhInstance;
	private int numberofWaves = 0;
	private bool canCreateBH;
	bool canCreateTriggerZone;
    private float bhTimer = 5f;

	// Use this for initialization
	void Start () {
		canCreateTriggerZone = false;
	}
	
	// Update is called once per frame
	void Update () {

	 
		if((enemyUFOInstance == null) && (ciaAgentInstanceUP == null) && (ciaAgentInstanceDOWN == null) && (numberofWaves <=2)) {

			if(canCreateTriggerZone) {
				print ("Create new trigger zone");

				canCreateTriggerZone = false;

				GameObject TriggerInstance;
				TriggerInstance = Instantiate (TriggerZone, new Vector3 (9, -1.5f, Player.transform.position.z + 80), TriggerZone.transform.rotation) as GameObject;

			
			}

		}	 

		if (numberofWaves > 2) {
			canCreateBH = true;
			bhTimer -= Time.deltaTime;
		
		}

		if ((canCreateBH == true) && (bhTimer <= 0)) {
		
			bhInstance =  Instantiate (blackHawk, new Vector3 (0, 10, Player.transform.position.z + 35), blackHawk.transform.rotation) as GameObject;
			canCreateBH = false;
		}
	
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			print ("Collide");

			enemyUFOInstance =  Instantiate (UFOprefab, new Vector3 (Player.transform.position.x, Player.transform.position.y +14, Player.transform.position.z + 35), UFOprefab.transform.rotation) as GameObject;
			ciaAgentInstanceUP =	Instantiate (ciaAgent, new Vector3 (-7, 0.3f, Player.transform.position.z + Random.Range (15, 25)), ciaAgent.transform.rotation) as GameObject;
			ciaAgentInstanceDOWN =	Instantiate (downciaAgent, new Vector3 (-2, 0.3f, Player.transform.position.z + Random.Range (15, 25)), downciaAgent.transform.rotation) as GameObject;
			canCreateTriggerZone = true;
			numberofWaves +=1;



		}
	}
}
