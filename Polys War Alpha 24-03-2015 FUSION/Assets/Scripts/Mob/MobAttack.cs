/**
 * author : Cha
 */

using UnityEngine;
using System.Collections;

public class MobAttack : MonoBehaviour {

	// composants

	// mob
	[SerializeField]
	Mob m = null;

	// quand le mob rentre dans une base
	void OnTriggerEnter(Collider col){
		Debug.Log("hahaha");
		// si c'est un adversaire
		if (!col.gameObject.CompareTag (this.tag)) {
			// la base perd de la vie
			col.gameObject.GetComponent<Base>().loseLife(m.getDamage());
			// le mob meurt
			m.deadBoy();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
