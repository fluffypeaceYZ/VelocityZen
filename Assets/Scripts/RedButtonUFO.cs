using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButtonUFO : MonoBehaviour {
	public float switchTimer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		switchTimer -= Time.deltaTime;
		if (switchTimer <=0){

			switchTimer = 1.8f;
		}


		if (switchTimer >= 0.9f)  {

			gameObject.GetComponent<Renderer> ().material.color = Color.red;
			/*isGreen = true;
			isRed = false;
			Renderer rend = GetComponent<Renderer>();
			rend.material.shader = Shader.Find("Specular");
			rend.material.SetColor("_SpecColor", Color.red);*/
		}

		if (switchTimer <= 0.9f)  {

			gameObject.GetComponent<Renderer> ().material.color = Color.green;
			/*isRed = true;
			isGreen = false;
		
			Renderer rend = GetComponent<Renderer>();
			rend.material.shader = Shader.Find("Specular");
			rend.material.SetColor("_SpecColor", Color.green);*/
		}

		
	}
}
