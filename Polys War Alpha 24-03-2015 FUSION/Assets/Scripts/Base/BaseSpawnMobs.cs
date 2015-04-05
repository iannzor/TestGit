using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct stats
{
	public GameObject mob;
	public int score;
}

public class BaseSpawnMobs : MonoBehaviour {

	// composants

	// Mobs
	[SerializeField]
	List<GameObject> mobs = new List<GameObject>();

	// nombre total de mobs
	int nbrTotalMobs = 9;

	int nextWave = 9;

	// time interval
	[SerializeField]
	float interval = 2;

	// destination
	[SerializeField]
	Transform destination = null;

	// spawn
	[SerializeField]
	Transform spawn = null;

	// start timer
	float _startTimer = 0;
	
	// type courant
	int currentType = 0;

	[SerializeField]
	BattleState TimeLeft;

	// bool startSpawning
	bool startSpawning = false;
	bool first = true;

	GameObject Clone;


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		if(startSpawning && Network.isServer){

			_startTimer += Time.deltaTime;
			if(_startTimer >= interval){
				GameObject mobclone = (GameObject)Network.Instantiate(mobs[currentType], spawn.position, Quaternion.identity, 1);

				var mobID = mobclone.GetComponent<NetworkView>().viewID;

				//AddTagRecursively(mobclone.transform, gameObject.tag);

				GetComponent<NetworkView>().RPC ("SetMobTag",RPCMode.All, mobID, gameObject.tag);

				NavMeshAgent nMesh = mobclone.GetComponent<NavMeshAgent>();
				nMesh.destination = destination.position;
				_startTimer = 0;
				currentType++;
				nbrTotalMobs--;


				if(currentType >= mobs.Count){
					currentType = 0;

				if (nbrTotalMobs <= 0)
				{
						if(first)
						{
							Clone = GameObject.Find ("Player(Clone)");
							TimeLeft = Clone.GetComponent<BattleState> ();
							first = false;
						}

					startSpawning = false;
					nextWave += (int)Mathf.Round(nextWave/2);
					nbrTotalMobs = nextWave;
					TimeLeft.StartTimer = true;
						Debug.Log (TimeLeft.StartTimer);
				}

				}
			}
		}

	}	


	public void Spawning()
	{
		startSpawning = true;
	}

	void AddTagRecursively(Transform trans, string tag)
	{

		trans.gameObject.tag = tag;
		if(trans.childCount > 0)
			foreach(Transform t in trans)
				AddTagRecursively(t, tag);
	}


	[RPC]
	void SetMobTag(NetworkViewID id, string tag)
	{
		NetworkView.Find (id).gameObject.tag = tag;
	}

}
