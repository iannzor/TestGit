using UnityEngine;
using System.Collections;
public class initializationScript : MonoBehaviour {




	// Use this for initialization
	void Start () {



		if (GetComponent<NetworkView>().isMine == false){ 
			
			gameObject.GetComponent<FPSWalker>().enabled  = false;
			gameObject.GetComponent<MouseLook>().enabled  = false;
			gameObject.GetComponent<initializationScript>().enabled  = false;
			gameObject.GetComponent<Player>().enabled  = false;
			gameObject.GetComponentInChildren<LaserScript>().enabled = false;
			gameObject.GetComponentInChildren<Camera>().enabled = false; 
			gameObject.GetComponentInChildren<GUILayer>().enabled = false;
			gameObject.GetComponentInChildren<AudioListener>().enabled = false;
			gameObject.GetComponentInChildren<MouseLook>().enabled = false;
			gameObject.GetComponentInChildren<InitiateOnClick>().enabled = false;

					
			//gameObject.GetComponentInChildren<NetworkView>().enabled = false;

		}
	


	}
	
	// Update is called once per frame
	void Update () {

		//if (Network.isClient || Network.isClient)
	}

	
}

