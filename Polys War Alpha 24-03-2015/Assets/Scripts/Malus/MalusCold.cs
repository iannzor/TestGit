/**
 * author : Cha
 */

using UnityEngine;
using System.Collections;

public class MalusCold : Malus {

	// Variable
	
	// pourcentage en moins
	[SerializeField]
	float speedless = 10;
	
	// on baisse la vitesse du mob
	public override void Fire(){
		mob.setSpeed (mob.getMaxSpeed() - (mob.getMaxSpeed() * this.speedless / 100));
	}

	// on remet la vitesse du mob à la normal
	public override void Disfire(){
		mob.setSpeed (mob.getMaxSpeed());
	}

}
