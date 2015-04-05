/**
 * author : Cha
 */

using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
	
	// Caractéristiques des tours
	
	// Vitesse
	[SerializeField]
	float speed = 10;
	// dégats
	[SerializeField]
	float damage = 10;
	// portée attaque
	[SerializeField]
	float scopeAttack = 10;
	// portée évolution
	[SerializeField]
	float scopeEvolve = 2;
	// price
	[SerializeField]
	float price = 100;
	// pouvoir
	[SerializeField]
	Malus power = null;
	// renderer bar type
	[SerializeField]
	Renderer typeBar = null;
	
	public float getScopeAttack(){
		return this.scopeAttack;
	}
	
	public float getScopeEvolve(){
		return this.scopeEvolve;
	}
	
	public float getDamage()
	{
		return this.damage;
	}
	
	public float getSpeed()
	{
		return this.speed;
	}
	
	public Malus getPower(){
		return this.power;
	}
	
	void Start(){
		// pour afficher le type de la tour
		if (power != null) {
			// on affecte le bon maerial
			typeBar.material = power.getMat();
		}
	}
}
