using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMS : MonoBehaviour {

	public GameObject MedKit;
	public GameObject ShieldCharger;
	public GameObject TriggerZoneMS;
	public GameObject Player;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {


		
	}




	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			print ("TRIGGERMS COLLISION");
			GameObject MedKitInstance;
			MedKitInstance =  Instantiate (MedKit, new Vector3 (Random.Range (-7,7), 0, Player.transform.position.z + Random.Range (100,300)), MedKit.transform.rotation) as GameObject;
			GameObject ShieldChargerInstance;
			ShieldChargerInstance = Instantiate (ShieldCharger, new Vector3 (Random.Range (-7,7), 0, Player.transform.position.z +  Random.Range (100,300)), ShieldCharger.transform.rotation) as GameObject;
			GameObject TriggerZoneMSInstance;
			TriggerZoneMSInstance = Instantiate (TriggerZoneMS, new Vector3 (9, -1.5f, Player.transform.position.z + 700), TriggerZoneMS.transform.rotation) as GameObject;
		}



		}
}
