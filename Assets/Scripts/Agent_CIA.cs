using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent_CIA : MonoBehaviour {

	public Animation animation;

	// Use this for initialization
	void Start () {

		animation = gameObject.GetComponent<Animation>();
		
	}
	
	// Update is called once per frame
	void Update () {

		animation.Play("walkbackwards");
		
	transform.position += new Vector3(0, 0, 0.4f);
		}
	}
