using UnityEngine;
using System.Collections;

public class OnTrigger : MonoBehaviour {

	static public bool buildable;
	static public int i;


	// Use this for initialization
	void Start () {

		buildable = false;
		i = 0;
	
	}
	
	// Update is called once per frame
	void Update () {



	}

	void OnTriggerEnter(Collider other)
	{
	

		i++;

		Debug.Log (i);
		if (i == 1)
			buildable = true;

		if (i>1) 
			buildable = false;



	}

	void OnTriggerExit(Collider other)
	{
		i--;
		if (i == 1)
			buildable = true;
			

	}
}
