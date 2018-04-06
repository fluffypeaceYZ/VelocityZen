using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Return)|| (Input.GetKeyDown (KeyCode.JoystickButton0))) {

			SceneManager.LoadScene ("level_1");

		}

		
	}
}
