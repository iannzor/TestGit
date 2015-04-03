/**
 * author : Cha
 */

using UnityEngine;
using System.Collections;

public class Malus : MonoBehaviour {

	// variables

	// durée totale
	[SerializeField]
	protected float duration = 10;
	// mob
	[SerializeField]
	protected Mob mob = null;
	// material
	[SerializeField]
	protected Material mat = null;

	// start timer
	protected float startTimer = 0f;

	public void setMob(Mob oMob){
		this.mob = oMob;
	}

	public Material getMat(){
		return this.mat;
	}

	// Update is called once per frame
	public virtual void Update () {
		// on lance le malus
		Fire ();
		// on incrémente le timer
		startTimer += Time.deltaTime;
		// si le temps est dépasser
		if (startTimer >= this.duration) {
			// on défait le malus
			Disfire();
			// on le kick
			Destroy(this);
		}
	}

	// fonction qui permet de lancer le malus
	public virtual void Fire(){

	}

	// fonction qui permet de défaire les malus avant leur mort
	public virtual void Disfire(){

	}

}
