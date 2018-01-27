﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserUFO : MonoBehaviour {

	public ParticleSystem hitsmoke;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	} 

	void OnCollisionEnter (Collision col){
			
		if ((col.gameObject.tag == "Ground") || (col.gameObject.tag == "Player")) {
			
			hitsmoke.Play();
		
			Destroy (this.gameObject, 0.5f);
		}
	}
}
