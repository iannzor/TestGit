/*
 * Author : Iann
 */

using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
	
	static int nbPlayer = 0;
	
	[SerializeField]
	GameObject joueur, clone, clone2;
	
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
	
	// Use this for initialization
	void Start () {

		
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
			clone.tag = "red";
			var CloneID = clone.GetComponent<NetworkView>().viewID;
			
			GetComponent<NetworkView>().RPC ("setTag", RPCMode.OthersBuffered, CloneID, "red");
			
			
			//clone.SetActive(true);
			team = "red";
			enemy = "blue";
			
		} else if (Network.isClient) {
			
			
			//GetComponent<NetworkView>().RPC("setTag", RPCMode.Others);
			
			clone2 = Network.Instantiate (joueur, spawnblue.transform.position, spawnblue.transform.rotation, 0) as GameObject;
			clone2.tag = "blue";
			
			var CloneID = clone2.GetComponent<NetworkView>().viewID;
			GetComponent<NetworkView>().RPC ("setTag", RPCMode.Server, CloneID, "blue");
			//clone2.SetActive(true);
			//
			team = "blue";
			enemy = "red";
			
			
			
			
		}
		
	}
	
	
	
	[RPC]
	void setTag(NetworkViewID id, string tag)
	{
		NetworkView.Find (id).gameObject.tag = tag;
	}
	
}
