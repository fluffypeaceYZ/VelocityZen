﻿using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour
{
    float BottomScreen = 10f;
    float UpperScreen = -7.4f;
	public Material matHit;
	public Color colRed;


	 
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.C)){

		}


        transform.position += new Vector3(0, 0, 0.1f);


		if (Input.GetKey(KeyCode.UpArrow) || (Input.GetAxis("StrafingLeft") < 0))

        {
            transform.position -= new Vector3(0.1f, 0, 0);
        }

		if (Input.GetKey(KeyCode.DownArrow) || (Input.GetAxis("StrafingLeft") > 0))

        {
            transform.position += new Vector3(0.1f, 0, 0);
        }

        if (transform.position.x >= BottomScreen)

        {
            transform.position = new Vector3(BottomScreen, transform.position.y, transform.position.z);
        }

        else if (transform.position.x <= UpperScreen)

        {
            transform.position = new Vector3(UpperScreen, transform.position.y, transform.position.z);

        }
    }

}

