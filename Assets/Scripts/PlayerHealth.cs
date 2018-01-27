using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public GameObject GameOverScreen;

	public Sprite[] healthBarArray;
	public Image healthBar;

	private int healthBarCount = 0;

	void Start () 
	{

	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.P))
		{
			TakeDamage ();


		}

		if (Input.GetKeyDown (KeyCode.Escape)) {

			SceneManager.LoadScene ("Sneak_FPS");

		}


	}

	public void TakeDamage()
	{
		healthBarCount++;

		if (healthBarCount >= 12){

			GameOver ();
		}

		healthBar.sprite = healthBarArray [healthBarCount];
	}

	public void HealDamage(){

		healthBarCount = 0;
		healthBar.sprite = healthBarArray [healthBarCount];
	}

	void OnTriggerEnter (Collider other) {



		if (other.gameObject.tag == "Health") {
			HealDamage ();
			Destroy (other.gameObject);


		}
	}

	void OnCollisionEnter (Collision col){

			if (col.gameObject.tag == "LaserUFO") {

			TakeDamage ();
			}

	}

	void GameOver()
	{
		GameOverScreen.SetActive (true);
	}
}

