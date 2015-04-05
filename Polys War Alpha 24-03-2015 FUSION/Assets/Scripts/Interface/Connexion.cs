/*
 * Author : Iann
 */

using UnityEngine;
using System.Collections;
using System;

public class Connexion : MonoBehaviour {
	
	
	[SerializeField]
	GameObject score;


	
	bool player1isConnected = false;
	bool player2isConnected = false;
	public bool soloPlay = true;
	
	
	void Start () {
		
		if (Network.isServer)
			player1isConnected = true;
		
		if (Network.isClient)
			GetComponent<NetworkView>().RPC ("isclientConnected", RPCMode.Server);
		
		if (soloPlay)
			isclientConnected ();
	}
	
	
	[RPC]
	void isclientConnected()
	{
		player2isConnected = true;
		
		if (player1isConnected && player2isConnected)
			GetComponent<NetworkView>().RPC ("activateScript", RPCMode.All);
		
	}
	
	[RPC]
	void activateScript()
	{
		score.gameObject.SetActive(true);

		//gameObject.SetActive(false);
	}
}
