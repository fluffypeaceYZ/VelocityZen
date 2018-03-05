using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMS : MonoBehaviour {

	public GameObject MedKit;
	public GameObject ShieldCharger;
	public GameObject TriggerZoneMS;
	public GameObject Player;
	GameObject MedKitInstance;
	GameObject ShieldChargerInstance;
	GameObject TriggerZoneMSInstance;
	bool canCreateTrigger;

	// Use this for initialization
	void Start () {
		canCreateTrigger = false;
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}

	void CreateTrigger(){
	
		if (canCreateTrigger = true) {

			TriggerZoneMSInstance = Instantiate (TriggerZoneMS, new Vector3 (9, -1.5f, Player.transform.position.z + 200), TriggerZoneMS.transform.rotation) as GameObject;
			canCreateTrigger = false;
			print ("Created TriggerMS");

		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			print ("TRIGGERMS COLLISION");
			MedKitInstance =  Instantiate (MedKit, new Vector3 (Random.Range (-7,7), 0, Player.transform.position.z + Random.Range (100,300)), MedKit.transform.rotation) as GameObject;
			ShieldChargerInstance = Instantiate (ShieldCharger, new Vector3 (Random.Range (-7,7), 0, Player.transform.position.z +  Random.Range (100,300)), ShieldCharger.transform.rotation) as GameObject;
			canCreateTrigger = true; 
		}



		}
}
