using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public GameObject GameOverScreen;
	public Text HealthKits;
	private int NumberofKits = 0;
	private int MaxNumberofKits = 99;
	public Sprite[] healthBarArray;
	public Image healthBar;

	private int healthBarCount = 0;

	void Start () 
	{

	}

	void Update ()
	{
		if (healthBarCount <= 0) {

			NumberofKits = NumberofKits;
			HealthKits.text = NumberofKits.ToString();
		}

		if (Input.GetKeyDown (KeyCode.H) && NumberofKits>=1){

			NumberofKits-=1;
			HealthKits.text = NumberofKits.ToString();
			healthBarCount = 12;
			healthBar.sprite = healthBarArray[0];
		}

		if (Input.GetKeyDown (KeyCode.B)){

			NumberofKits+=1;
			HealthKits.text = NumberofKits.ToString();
		}

		if (NumberofKits >= 99) {
			NumberofKits = 99;
			HealthKits.text = NumberofKits.ToString();
		}

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
		healthBarCount+=2;

		if (healthBarCount >= 12){

			healthBar.sprite = healthBarArray [11];
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


			NumberofKits+=1;
			HealthKits.text = NumberofKits.ToString();
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

