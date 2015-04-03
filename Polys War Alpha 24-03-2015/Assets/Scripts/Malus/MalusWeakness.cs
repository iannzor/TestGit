/**
 * author : Cha
 */

using UnityEngine;
using System.Collections;

public class MalusWeakness : Malus {

	// Variable

	// pourcentage en moins
	[SerializeField]
	float strenghtless = 10;

	// on baisse l'armure
	public override void Fire(){
		mob.setArmor (mob.getMaxArmor() - (mob.getMaxArmor() * this.strenghtless / 100));
	}

	// on remet à la normale
	public override void Disfire(){
		mob.setArmor (mob.getMaxArmor());
	}
}
