﻿/**
 * author : Cha
 * modifier : Iann
 */

using UnityEngine;
using System.Collections;

public class BaseHeal : MonoBehaviour {

	// composant

	// la base et ses méthodes
	[SerializeField]
	Base b = null;

	// temps entre deux heals
	[SerializeField]
	float middle = 5;

	// pourcentage de heal 
	[SerializeField]
	float pourcent = 0.25f;

	// start timer
	float startTimer = 0;

	// hey
	Player ownPlayer = null;

	// actived health
	bool activatedHeal = false;

	// quand un player rentre
	void OnTriggerEnter(Collider col){
		// si ce n'est pas un adversaire
		if (col.gameObject.CompareTag (this.tag)) {
			activatedHeal = true;
			ownPlayer = col.GetComponent<Player>();
			Debug.Log ("it works ?");
		}
	}

	// quand un player sort
	void OnTriggerExit(Collider col){
		// on arrete de la heal
		if (col.gameObject.CompareTag (this.tag)) {
			activatedHeal = false;
			ownPlayer = null;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (activatedHeal) {

			startTimer += Time.deltaTime;
			if(startTimer >= middle){
				Heal();

				startTimer = 0;
			}
		}
	}

	// redonner de la vie au player
	void Heal(){
		// on calcul en fonction de la distance du player et du pourcentage de heal accepté
		Debug.Log ("get health");
		Debug.Log (ownPlayer.getHealth());
		float temp = ownPlayer.getHealth () * (Vector3.Distance(this.gameObject.transform.position, ownPlayer.gameObject.transform.position) / b.getScopeHealthPlayer() * this.pourcent);
		Debug.Log ("HEAL AMOUT");
		Debug.Log (temp);	
		// on heal le player
		ownPlayer.winLife (temp);
	}
}
