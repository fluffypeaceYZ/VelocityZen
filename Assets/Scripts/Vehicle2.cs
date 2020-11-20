using UnityEngine;
using System.Collections;

public class Vehicle2 : MonoBehaviour
{
	float BottomScreen = 1.25f;
    float UpperScreen = -16.72f;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(0, 0, 0.2f);


        if (Input.GetKey(KeyCode.UpArrow))

        {
            transform.position -= new Vector3(0.2f, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))

        {
            transform.position += new Vector3(0.2f, 0, 0);
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

