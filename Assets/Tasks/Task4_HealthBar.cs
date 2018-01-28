using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Task4_HealthBar : MonoBehaviour
{
	public GameObject GameOverScreen;
	public Text HealthKits;
	private int NumberofKits = 0;
	private int MaxNumberofKits = 99;
	public Sprite[] healthBarArray;
	public Image healthBar;

	private int healthBarCount = 12;

	void Start () 
	{

	}

	void Update ()
	{//This right here is what I tried to fix it but the number of kits still goes down.
		if (healthBarCount > 12) {

			NumberofKits = NumberofKits;
			HealthKits.text = NumberofKits.ToString();
		}
	//End of problematic code.  
		if (Input.GetKeyDown (KeyCode.H) && NumberofKits>=1){

			NumberofKits-=1;
			HealthKits.text = NumberofKits.ToString();
			healthBarCount = 12;
			healthBar.sprite = healthBarArray[11];
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
		healthBarCount-=2;

		if (healthBarCount <= 0){

			healthBar.sprite = healthBarArray [0];
			GameOver ();
		}

		healthBar.sprite = healthBarArray [healthBarCount];
	}

	public void HealDamage(){

		healthBarCount = 12;
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


