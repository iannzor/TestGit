/**
 * author : Iann
 * modifier : Cha
 */

using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {
	
	// Caractéristiques des mobs
	
	// Vie 
	[SerializeField]
	float health = 10f;
	// Vie maximum
	[SerializeField]
	float maxHealth = 10f;
	// Armure
	[SerializeField]
	float armor = 1;
	// Armure max
	[SerializeField]
	float maxArmor = 1;
	//Vitesse
	[SerializeField]
	float speed = 10;
	// speed max
	[SerializeField]
	float maxSpeed = 10;
	// dégats
	[SerializeField]
	float damage = 10;
	// Portée
	[SerializeField]
	float scope = 10;
	// argent
	[SerializeField]
	float gold = 10;
	
	//couleur de la barre de vie en fonction du camp
	
	// rouge
	[SerializeField]
	float red = 0;
	//vert
	[SerializeField]
	float green = 0;
	//bleu
	[SerializeField]
	float blue = 0;
	
	//Composants
	
	// le renderer du quad (healthbarre)
	[SerializeField]
	Renderer healthRend;
	// le navmesh
	[SerializeField]
	NavMeshAgent navSpeed;
	// le mesh renderer pour changer la couleur du material
	[SerializeField]
	MeshRenderer ownMeshRenderer = null;
	// le collider
	//[SerializeField]
//	SphereCollider coll;

	public void setRed(float otherRed){
		this.red = otherRed;
	}

	public void setGreen(float otherGreen){
		this.green = otherGreen;
	}

	public void setBlue(float otherBlue){
		this.blue = otherBlue;
	}

	public void setArmor(float oArmor)	{
		this.armor = oArmor;
	}
	
	public float getMaxArmor(){
		return this.maxArmor;
	}
	
	public void setSpeed(float oSpeed){
		this.speed = oSpeed;
		navSpeed.speed = oSpeed;
	}
	
	public float getMaxSpeed(){
		return this.maxSpeed;
	}
	
	public float getDamage(){
		return this.damage;
	}
	
	// mort du mob
	public void deadBoy() {   
		Destroy (gameObject);
		//Score.gold = Score.gold + gold;
		//GetComponent<NetworkView>().RPC("getrekt", RPCMode.All); 
	}
	
	[RPC]
	public void getrekt(){
		Destroy(gameObject); 
	}
	
	// initialisation
	public void Start()
	{
		//changement de la vitesse du mob
		navSpeed.speed = speed;
		//changement de la portée du mob
		//coll.radius = scope;
		// affectation des valeurs au shader

		if (this.tag == "red") {
			setRed (1f);
			ownMeshRenderer.materials[1].color = new Color(255, 0, 0);
		} else if (this.tag == "blue") {
			setBlue(1f);
			ownMeshRenderer.materials[1].color = new Color(0, 0, 255);
		}

		// la vie maximum
		healthRend.material.SetFloat ("_MaxHps", maxHealth);
		// la vie
		healthRend.material.SetFloat ("_Hps", health);
		// le rouge
		healthRend.material.SetFloat ("_Red", red);
		// le bleu
		healthRend.material.SetFloat ("_Blue", blue);
		// le vert
		healthRend.material.SetFloat ("_Green", green);
	}
	
	// chaque frame
	public void Update()
	{
	}
	
	// lorsque le mob est blessé
	public void loseLife(float oDamage)
	{
		// on calcul la perte de vie en fonction de l'armure
		health = health - (oDamage - (oDamage * armor / 10));
		// si la vie est null ou négative, le mob meurt
		if (health <= 0) {
			deadBoy();
		}
		// on met à jour la valeur vie du shader pour l'affichage
		healthRend.material.SetFloat ("_Hps", health);
	}
	
	[RPC]
	public void reload()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
	
	
}