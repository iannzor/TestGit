/**
 * author : Cha
 */

using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Variables

	//dégats
	[SerializeField]
	float damage = 0;

	// pouvoir
	[SerializeField]
	Malus power = null;

	// durée de vie 
	[SerializeField]
	float duration = 10;

	// start timer
	float startTimer = 0;


	// composants

	// rigidbody
	[SerializeField]
	Rigidbody rigid = null;



	// get le rigidbody
	public Rigidbody getRigid(){
		return this.rigid;
	}
	

	// set les dégâts
	public void setDamage(float oDamage){
		this.damage = oDamage;
	}

	// get les dégâts
	public float getDamage(){
		return this.damage;
	}

	// set le pouvoir
	public void setPower(Malus oPower){
		this.power = oPower;
	}

	// get le pouvoir
	public Malus getPower(){
		return this.power;
	}



	// Update is called once per frame
	void Update () {
		// on incrémente le timer
		startTimer += Time.deltaTime;
		// si le temps est dépasser
		if (startTimer >= this.duration) {
			Destroy(this.gameObject);
		}
	}

	// lors d'une collision
	void OnTriggerEnter(Collider coll){
		// on récupère le mob
		GameObject target = coll.gameObject;
		Debug.Log (target);
		// si le mob est un adversaire
		if (!target.CompareTag (this.tag)) {
			// on obtient le composant Mob
			Mob mobTarget = target.GetComponent<Mob> ();
			Debug.Log(mobTarget);
			// on fait perdre de la vie
			mobTarget.loseLife (this.damage);
			// si on a un malus
			if (this.power != null) {
				// on ajoute le malus au Mob
				Malus compo = (Malus)target.AddComponent(this.power.GetType());
				// on initialise les valeurs du composant
				compo.setMob(mobTarget);
			}
			// on détruit la bullet
			Destroy (gameObject);
		}
	}

}
