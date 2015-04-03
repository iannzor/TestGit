/**
 * author : Cha
 */

using UnityEngine;
using System.Collections;

public class MalusPoison : Malus {

	// durée intermédiaire
	[SerializeField]
	protected float middle = 2;
	// damage
	[SerializeField]
	protected float damage = 2;

	// un deuxième timer pour la durée intermédiaire
	protected float startPoisonTimer = 0;

	// Update is called once per frame
	public override void Update () {
		// on incrémente les timers
		startTimer += Time.deltaTime;
		startPoisonTimer += Time.deltaTime;
		if(startPoisonTimer >= this.middle){
			// on lance le malus
			Fire ();
			startPoisonTimer = 0;
		}
		// si le temps est dépasser
		else if (startTimer >= this.duration) {
			// on le kick
			Destroy(this);
		}
	}

	// on empoisonne le mob
	public override void Fire(){
		// on fait perdre de la vie
		mob.loseLife(this.damage);
	}
}
