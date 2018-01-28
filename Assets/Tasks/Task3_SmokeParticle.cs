using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3_SmokeParticle : MonoBehaviour {


		public ParticleSystem hitsmoke;

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		} 
	//The smoke Particle gets destroyed with the game object, I need the laser destroyed within 1 second and the SMoke effect within 2 seconds
		void OnCollisionEnter (Collision col){

			if ((col.gameObject.tag == "Ground") || (col.gameObject.tag == "Player")) {

				hitsmoke.Play();

				Destroy (this.gameObject, 2.0f);
			}
		}
	}

