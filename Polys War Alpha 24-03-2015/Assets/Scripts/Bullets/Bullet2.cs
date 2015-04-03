using UnityEngine;
using System.Collections;

public class Bullet2 : MonoBehaviour {

	// Variables

	//dégats
	[SerializeField]
	float damage = 0;

	// pouvoir
	[SerializeField]
	Component power = null;


	public void setDamage(float oDamage){
		this.damage = oDamage;
	}

	public float getDamage(){
		return this.damage;
	}

	public void setPower(Component oPower){
		this.power = oPower;
	}

	public Component getPower(){
		return this.power;
	}

	void OnTriggerEnter(Collider coll){
		GameObject target = coll.gameObject;
		if (!target.CompareTag (gameObject.tag)) {
			target.GetComponent<Mob> ().loseLife (this.damage);
			if (this.power != null) {
				target.AddComponent (this.power.GetType ());
			}
			Debug.Log ("Hit !");
			Network.Destroy(gameObject);
			//GetComponent<NetworkView>().RPC("destroyBullet", RPCMode.All);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	[RPC]
	void destroyBullet()
	{
		Destroy (gameObject);
	}*/
}
