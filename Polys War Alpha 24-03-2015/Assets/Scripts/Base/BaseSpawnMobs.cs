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

	// copie du tableau des monstres
	List<GameObject> copyMobs = null;

	// nombre de chaque type de mobs 
	int nbrMaxMobs = 3;

	// nombre total de mobs
	int nbrTotalMobs = 9;

	// time interval
	[SerializeField]
	float interval = 2;

	// destination
	[SerializeField]
	Transform destination = null;

	// spawn
	[SerializeField]
	Transform spawn = null;

	// tableau des nombres
	int[] nbrMobsTypes;

	// start timer
	float startTimer = 0;

	// bool fake
	bool fake = true;

	// initialisation du tableau
	void initiateNbrMobsTypes(){
		for (int i = 0; i < mobs.Count; i++) {
			nbrMobsTypes[i] = nbrMaxMobs;
		}
	}

	// Use this for initialization
	void Start () {
		nbrMobsTypes = new int[mobs.Count];
		initiateNbrMobsTypes ();
	}
	
	// Update is called once per frame
	void Update () {
		if(fake){
			startTimer += Time.deltaTime;
			if(startTimer >= interval){
				int nbrTempMobs = 0;
				int choice;
				do{
					choice = Random.Range(0, mobs.Count - 1);
				}while("" == "");
				//GameObject mobclone = Network.Instantiate(mobs[choice], spawn.position, Quaternion.identity, 0) as GameObject;
				//NavMeshAgent nMesh = mobclone.GetComponent<NavMeshAgent>();
				//nMesh.destination = destination.position;
				//Debug.Log("Spawn !!!!!!!!!!!!!!!!!!!! choice " + choice);
				startTimer = 0;
				nbrMobsTypes[choice]--;
				nbrTempMobs++;
			}
		}
	}

	void AddTagRecursively(Transform trans, string tag)
	{
		trans.gameObject.tag = tag;
		if(trans.childCount > 0)
			foreach(Transform t in trans)
				AddTagRecursively(t, tag);
	}
}
