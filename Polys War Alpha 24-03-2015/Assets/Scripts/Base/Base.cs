/**
 * author : Cha
 */

using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

	// Variables

	// vie
	[SerializeField]
	float health = 200;

	// armure
	[SerializeField]
	float armor = 1;

	// scope healthplayer
	[SerializeField]
	float scopeHealthPlayer = 10;

	public float getScopeHealthPlayer(){
		return this.scopeHealthPlayer;
	}

	// perte de vie
	public void loseLife(float oDamage){
		// on calcul la perte de vie en fonction de l'armure
		health = health - (oDamage - (oDamage * armor / 10));
		// si la vie est null ou négative, le mob meurt
		if (health <= 0) {
			// fin de partie !
			Debug.Log("GG");
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
