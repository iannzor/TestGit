using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour {


	[SerializeField]
	InputField port = null;

	[SerializeField]
	InputField adresse_ip = null;


	void Start()
	{
		//Evite que le jeu soit en pause si il est en background
		Application.runInBackground = true;

	}

	public void StartServer ()
	{
	
		try {
			//Network.InitializeSecurity ();
			Network.InitializeServer (2, int.Parse(port.text), true);
			Application.LoadLevel("Polys War");
		} catch (Exception e) {
			Debug.Log (e.Message);
		}
	}


	public void StartClient ()
	{
		try {
			Network.Connect (adresse_ip.text, int.Parse (port.text));
			Application.LoadLevel("Polys War");
		} catch (Exception e) {
			Debug.LogError (e.Message);
		}
	}

	public void ExitGame()
	{
		Application.Quit ();
	}


}	
