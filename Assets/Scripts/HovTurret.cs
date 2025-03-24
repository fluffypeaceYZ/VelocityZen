using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HovTurret : MonoBehaviour {

    public GameObject agentBulletSpawn;
	public GameObject agentBulletInstance;
	public float agentBullet_Forward_Force;
	public float agentBulletTimer;
	public AudioClip AgentBullet;
	AudioSource audioSource;
	public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        agentBulletTimer -= Time.deltaTime;



        if (agentBulletTimer <= 0)
        {
            GameObject Temporary_AgentBullet_Handler;
            Temporary_AgentBullet_Handler = Instantiate(agentBulletInstance, agentBulletSpawn.transform.position, agentBulletSpawn.transform.rotation) as GameObject;
            agentBulletTimer = 1;


            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_AgentBullet_Handler.transform.Rotate(Vector3.left * 90);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_AgentBullet_Handler.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            //Temporary_RigidBody.AddForce(transform.forward * Laser_Forward_Force);
            Temporary_RigidBody.AddForce(0, -3, -13, ForceMode.Impulse);
            audioSource.PlayOneShot (AgentBullet, 1);

            //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
            Destroy(Temporary_AgentBullet_Handler, 4.0f);
        }
    }
}
