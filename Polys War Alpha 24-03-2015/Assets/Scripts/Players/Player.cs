/**
 * author : Cha / Iann
 */

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// variables

	// vie 
	[SerializeField]
	float health = 100f;

	// max vie 
	[SerializeField]
	float maxHealth = 100f;

	// damage
	[SerializeField]
	float damage = 10f;

	// armure
	[SerializeField]
	float armor = 2f;

	// spawn
	[SerializeField]
	Transform spawnPosition;

	public float getHealth(){
		return health;
	}

	// perte de vie
	public void loseLife(float oDamage){
		// on calcul la perte de vie en fonction de l'armure
		health = health - (oDamage - (oDamage * armor / 10));

		// si la vie est null ou négative, le mob meurt
		if (health <= 0) {
			// respawn
			Debug.Log("Player respawn with all life");
			this.transform.position = spawnPosition.position;
			// life
			health = maxHealth;
			// gold for the ennmy
			Debug.Log ("Ennemy player win gold");
		}

	}

	// gain de vie
	public void winLife(float gain){
		// Si le gain de vie 
		if (health + gain <= maxHealth) {
			health = health + gain;
		} else {
			health = maxHealth;
		}
	}

	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.K))
		{

			Debug.Log ("zouzou");
			Debug.Log (getHealth());


		}
	}


	
}
