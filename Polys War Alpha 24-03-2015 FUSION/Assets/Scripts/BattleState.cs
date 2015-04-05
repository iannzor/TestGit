using UnityEngine;
using System.Collections;

public class BattleState : MonoBehaviour {

	[SerializeField]
	ConstructionState constructionState;
	[SerializeField]
	LaserScript shootScript;
	[SerializeField]
	InitiateOnClick constructionScript;

	GameObject BaseRed, BaseBlue;

	BaseSpawnMobs spawnRed, spawnBlue;

	float timeLeft;

	private bool startTimer;

	public bool StartTimer {
		get {
			return startTimer;
		}
		set {
			startTimer = value;
		}
	}


	bool first = true;

	void Start()
	{

		Debug.Log ("start");

	}
	// Use this for initialization
	void OnEnable () {

		if (first) 
		{
			BaseRed = GameObject.Find ("BaseRed");
			BaseBlue = GameObject.Find ("BaseBlue");
			spawnRed = BaseRed.GetComponent<BaseSpawnMobs> ();
			spawnBlue = BaseBlue.GetComponent<BaseSpawnMobs> ();
			first = false;
		}

		//startTimer = false;
		timeLeft = 0;
		StartTimer = false;

		if (Network.isServer)
			spawnRed.Spawning ();
			spawnBlue.Spawning ();

		if (GetComponent<NetworkView> ().isMine == true) {
			shootScript.enabled = true;
			constructionScript.enabled = false;

		}

	}
	
	// Update is called once per frame
	void Update () {

		if (StartTimer == true) {

			timeLeft += Time.deltaTime;


			if (timeLeft >= 10f) {
				Debug.Log ("Time To Build");
				constructionState.enabled = true;
				this.enabled = false;
			}
		}
	}
	/*
	public void StartTimer()
	{
		StartTimer2 = true;
	}
*/

}
