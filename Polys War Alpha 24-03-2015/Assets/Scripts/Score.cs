using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {


	static int nbPlayer = 0;
	public GameObject joueur, clone;
	public GameObject spawnred, spawnblue; 
	//private GameObject myspawn;
	public static string team = "";
	public static string enemy = "";
	public bool incPlayer = true;
	public bool isRIP = false;
	public static bool ready = false;
	public static int HP = 100;
	public static int gold = 200;
	bool playerConnected = false;

	[SerializeField]
	Player player = null;

	void OnGUI (){

		/*
		if (Network.isClient || Network.isServer) 
		{
			if (team == "") 
			{
				GUI.Box (new Rect(Screen.width/2-125, Screen.height/2-50, 250, 75), "Choose your team");
						if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 15, 75, 30), "R E D")) {
						team = "red";
						enemy = "blue";
						}
						if (GUI.Button (new Rect (Screen.width / 2 + 25, Screen.height / 2 - 15, 75, 30), "B L U E")) {
						team = "blue";
						enemy = "red";
						}
			}
		}

		if (team == "red" && incPlayer == true) {
					if(GUI.Button(new Rect(Screen.width/2-50, Screen.height/2-15, 100, 30), "Spawn !")){
					clone = Network.Instantiate (joueur, spawnred.transform.position, spawnred.transform.rotation, 0) as GameObject;
					//myspawn = Network.Instantiate(spawnblue, spawnblue.transform.position, spawnblue.transform.rotation, 0) as GameObject;
					incPlayer = false;
					}
				}
		else if (team == "blue" && incPlayer == true)
				{
					if(GUI.Button(new Rect(Screen.width/2-50, Screen.height/2-15, 100, 30), "Spawn !")){
					clone = Network.Instantiate(joueur, spawnblue.transform.position, spawnblue.transform.rotation, 0) as GameObject;
					//myspawn = Network.Instantiate(spawnblue, spawnblue.transform.position, spawnblue.transform.rotation, 0) as GameObject;
					incPlayer = false;
					}
				}

		if (Network.isServer)
				if (incPlayer == false && ready == false) {
						if (GUI.Button (new Rect (0, 0, 100, 30), "Ready !")) {
								ready = true;
						}
				}
*/
		GUI.Label (new Rect (0, 100, 100, 20), "Gold : "+gold.ToString());
		//GUI.Label (new Rect (0, 120, 100, 20), "HP : "+player.getHealth());


	}


	/*IEnumerator deadTime() {
		yield return new WaitForSeconds(2f);
		clone.SetActive (true);
	}*/

	// Use this for initialization
	void Start () {

		ready = false;
		isRIP = false;
		HP = 100;
		gold = 200;

		instantiatePlayer ();
		

	}
	
	// Update is called once per frame
	void Update () {

		if (HP <= 0)
			isRIP = true;

		if (isRIP == true && HP <= 0) 
		{
				//clone.SetActive(false);
				//StartCoroutine(deadTime()); 

				if (team == "blue")
					clone.transform.position = spawnblue.transform.position;
				if (team == "red")
					clone.transform.position = spawnred.transform.position;
			
				HP = 100;
		}


	}

	void instantiatePlayer()
	{
		
		if (Network.isServer) {
			
			clone = Network.Instantiate (joueur, spawnred.transform.position, spawnred.transform.rotation, 0) as GameObject;
			team = "red";
			enemy = "blue";
			
		} else if (Network.isClient) {
			clone = Network.Instantiate (joueur, spawnblue.transform.position, spawnblue.transform.rotation, 0) as GameObject;
			team = "red";
			enemy = "blue";
			ready = true;
		}

	}

	void checkForPlayers()
	{
		if (Network.isClient || Network.isServer && incPlayer == true)
			playerConnected = true;
		incPlayer = false;
		
		if (playerConnected == true)
			instantiatePlayer ();
		playerConnected = false;
	}
	
}
