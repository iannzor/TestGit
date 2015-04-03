/**
 * author : Cha
 */

using UnityEngine;
using System.Collections;

public class MalusStun : Malus {
	
	// durée intermédiaire
	[SerializeField]
	protected float middle = 2;
	// durée de stun
	[SerializeField]
	protected float stunTime = 2;
	// durée de non stun
	[SerializeField]
	protected float unStunTime = 3;

	private float startStun = 0;

	private bool stunActived = false;
	
	// un deuxième timer pour la durée intermédiaire
	protected float startPoisonTimer = 0;
	
	// Update is called once per frame
	public override void Update () {
		// on incrémente les timers
		startTimer += Time.deltaTime;
		startStun += Time.deltaTime;
		if (stunActived) {
			if (startStun >= stunTime) {
				Disfire ();
				stunActived = false;
				startStun = 0;
			}
		} else if (stunActived == false) {
			if(startStun >= unStunTime){
				Fire();
				stunActived = true;
				startStun = 0;
			}
		}
		// si le temps est dépasser
		else if (startTimer >= this.duration) {
			// on le kick
			Destroy(this);
		}
	}
	
	// on baisse la vitesse du mob
	public override void Fire(){
		mob.setSpeed (0);
	}
	
	// on remet la vitesse du mob à la normal
	public override void Disfire(){
		mob.setSpeed (mob.getMaxSpeed());
	}
}
