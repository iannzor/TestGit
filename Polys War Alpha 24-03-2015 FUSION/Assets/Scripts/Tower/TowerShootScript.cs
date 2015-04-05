/**
 * author : Cha
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerShootScript : MonoBehaviour {
	
	// composants
	
	// tower values
	[SerializeField]
	Tower t = null;
	
	// spawn bullet
	[SerializeField]
	Transform spawn = null;
	
	// bullet
	[SerializeField]
	GameObject bullet = null;
	
	// collider
	[SerializeField]
	SphereCollider sc = null;
	
	// champs privés
	
	// cibles
	List<GameObject> targets = new List<GameObject>();
	
	// shoot
	private bool canShoot = true;
	
	// quand un mob rentre
	void OnTriggerEnter(Collider col){
		// si c'est un adversaire
		if (!col.gameObject.CompareTag (this.tag)) {
			// on l'ajoute aux cibles
			this.targets.Add(col.gameObject);
		}
	}
	
	// quand un mob sort
	void OnTriggerExit(Collider col){
		// on l'enlève des cibles
		if (!col.gameObject.CompareTag (this.tag)) {
			this.targets.Remove (col.gameObject);
		}
	}
	
	void Start(){
		sc.radius = t.getScopeAttack ();
	}
	
	// Update is called once per frame
	void Update () {
		// si on a des cibles
		if (targets.Count != 0) {
			if(targets[0] == null){
				targets.Remove(targets[0]);
			}
			Fire ();
		}
	}
	/*
	// attack !!!!
	private void Fire(){
		// si on peut tirer
		if (canShoot) {
			// on change l'état
			canShoot = false;
			// on calcul la direction du tire
			Vector3 vec = targets[0].transform.position - spawn.transform.position;
			// on crée une balle
			Bullet b = new Bullet(vec);
			// on lui met le même tag que la tour
			b.gameObject.tag = gameObject.tag;
			// on prend le rigibody et on lui applique une force
			b.getRigid().AddForce(vec * 100);
			// on lui donne ses valeurs de dégâts
			b.setDamage(t.getDamage());
			// si on a un malus
			if(t.getPower() != null){
				// on lui ajoute le malus
				b.setPower(t.getPower());
			}
			// on recharge le tir de la tour
			StartCoroutine ("setCouldown");
			if (targets[0] == null)	{
				this.targets.Remove(targets[0]);
			}
		}
	}
*/
	// attack !!!!
	private void Fire(){
		// si on peut tirer
		if (canShoot) {
			// on change l'état
			canShoot = false;
			// on calcul la direction du tire
			Vector3 vec = targets[0].transform.position - spawn.transform.position;
			// on crée une balle
			GameObject b = (GameObject)Instantiate (bullet, spawn.transform.position, Quaternion.identity);
			// on lui met le même tag que la tour
			b.tag = gameObject.tag;
			// on lui donne ses valeurs de dégâts
			Bullet temp = b.transform.GetComponent<Bullet>();
			// on prend le rigibody et on lui applique une force
			temp.getRigid().AddForce(vec * 500);
			// dégâts
			temp.setDamage(t.getDamage());
			// si on a un malus
			if(t.getPower() != null){
				// on lui ajoute le malus
				temp.setPower(t.getPower());
			}
			// on recharge le tir de la tour
			StartCoroutine ("setCooldown");
			// si le mob meurt dans le collider
		}
	}
	
	// pour faire le rechargement de la tour
	private IEnumerator setCooldown()
	{
		yield return new WaitForSeconds(t.getSpeed());
		canShoot = true;
	}
}
