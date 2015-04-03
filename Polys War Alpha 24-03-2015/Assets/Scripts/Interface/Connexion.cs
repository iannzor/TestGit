using UnityEngine;
using System.Collections;
using System;

public class Connexion : MonoBehaviour {


	[SerializeField]
	GameObject score;
	/*
	public string adresse_ip = "";
	public string port = "";
	public string nb_player = "2";
		
	void OnGUI ()
	{

		if (!(Network.isServer ^ Network.isClient)) {

			GUILayout.BeginVertical ();
			
			GUILayout.BeginHorizontal ();
			
			GUILayout.Label ("Server IP : ");
			
			adresse_ip = GUILayout.TextField (adresse_ip);
			
			GUILayout.Label ("Server Port : ");
			
			port = GUILayout.TextField (port);

			GUILayout.EndHorizontal ();
			
			GUILayout.BeginHorizontal ();

			if (GUILayout.Button ("Start Client")) {
				StartClient ();
			}
			
			if (GUILayout.Button ("Start Server")) {
				StartServer ();
			}
			
			GUILayout.EndHorizontal ();
			
			GUILayout.EndVertical ();
		}
	}
	

	void StartServer ()
	{
		try {
			//Network.InitializeSecurity ();
			Network.InitializeServer (int.Parse (nb_player), int.Parse (port), true);
		} catch (Exception e) {
			Debug.LogError (e.Message);
		}
	}

	void StartClient ()
	{
		try {
			Network.Connect (adresse_ip, int.Parse (port));
		} catch (Exception e) {
			Debug.LogError (e.Message);
		}
	}


	
	}
	*/

	
	void Start () {


		
	}
	
	
	void Update () {

		if (Network.isClient || Network.isServer) 
		{
			score.gameObject.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}
