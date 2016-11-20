using UnityEngine;
using System.Collections;

public class CameraGhost2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += new Vector3(0, 0, 0.6f);

    }
}
