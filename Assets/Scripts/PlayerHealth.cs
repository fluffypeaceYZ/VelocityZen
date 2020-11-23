using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour

{
	public GameObject GameOverScreen;
	public Text HealthKits;
	public Text Shields;
	private int NumberofKits = 0;
	private int NumberofShields = 0;
	public Sprite[] healthBarArray;
	public Image healthBar;
	GameObject ShieldInstance;
	public GameObject Shield;
	public GameObject Player;
	public AudioClip crystal;
	public float shieldPosition;
	public float shieldDistance;
	AudioSource audioSource;




	private int healthBarCount;

	void Start () 
	{
		healthBarCount = healthBarArray.Length-1;
		audioSource = GetComponent<AudioSource>();
	}

	void Update ()
	{

		if (NumberofShields >= 99) {
			NumberofShields = 99;
			Shields.text = NumberofShields.ToString();
		}

		if (Input.GetKeyDown (KeyCode.G) && NumberofShields >= 1 || (Input.GetKeyDown (KeyCode.JoystickButton3)) && NumberofShields >= 1 && (ShieldInstance == null)) {
		
			audioSource.PlayOneShot(crystal, 1);

			ShieldInstance = Instantiate (Shield, new Vector3 (Player.transform.position.x, Player.transform.position.y+ shieldPosition, Player.transform.position.z + shieldDistance), Shield.transform.rotation) as GameObject;
		
			NumberofShields--;
			Shields.text = NumberofShields.ToString();
			Destroy (ShieldInstance.gameObject, 20);
		}

	



		if (Input.GetKeyDown (KeyCode.H) && NumberofKits >= 1 || (Input.GetKeyDown (KeyCode.JoystickButton0)) && NumberofKits>=1 && healthBarCount < 11)
		{
			NumberofKits -= 1;
			HealthKits.text = NumberofKits.ToString();
			healthBarCount = healthBarArray.Length;

			// Also try not to input numbers... you can get "11" by doing healthBarArray.length-1
			//healthBar.sprite = healthBarArray[11];

			// this will always get the last sprite in the array
			healthBar.sprite = healthBarArray[healthBarArray.Length - 1];
		}


		/*if (Input.GetKeyDown (KeyCode.B)){

			NumberofKits+=1;
			HealthKits.text = NumberofKits.ToString();
		}*/

		if (NumberofKits >= 99) {
			NumberofKits = 99;
			HealthKits.text = NumberofKits.ToString();
		}

		if (Input.GetKeyDown (KeyCode.P))
		{
			TakeDamage1 ();


		}

		if (Input.GetKeyDown (KeyCode.Escape)) {

			SceneManager.LoadScene ("level_1");

		}


	}

	public void TakeDamage1()
	{
		healthBarCount--;

		if (healthBarCount <= 0){

			healthBar.sprite = healthBarArray [0];
			GameOver ();
		}

		healthBar.sprite = healthBarArray [healthBarCount];
	}

	public void TakeDamage2()
	{
		healthBarCount-=2;

		if (healthBarCount <= 0){

			healthBar.sprite = healthBarArray [0];
			GameOver ();
		}

		healthBar.sprite = healthBarArray [healthBarCount];
	}

	public void HealDamage(){

		healthBarCount = 11;
		healthBar.sprite = healthBarArray [healthBarCount];
	}

	void OnTriggerEnter (Collider other) {



		if (other.gameObject.tag == "Health") {


			NumberofKits+=1;
			HealthKits.text = NumberofKits.ToString();
			Destroy (other.gameObject);


		}

		if (other.gameObject.tag == "ShieldCharger") {


			NumberofShields+=1;
			Shields.text = NumberofShields.ToString();
			Destroy (other.gameObject);


		}
	}

	void OnCollisionEnter (Collision col){

		if (col.gameObject.tag == "LaserUFO") {

			TakeDamage2 ();
		}

		if (col.gameObject.tag == "AgentBullet") {

			TakeDamage1 ();
		}
	}



	void GameOver()
	{
		SceneManager.LoadScene ("GameOver");
	}
}

