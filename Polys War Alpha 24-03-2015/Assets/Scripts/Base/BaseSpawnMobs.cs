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
	float startTimer = 0;
	
	// type courant
	int currentType = 0;

	// bool fake
	bool fake = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(fake){
			startTimer += Time.deltaTime;
			if(startTimer >= interval){
				GameObject mobclone = (GameObject)Instantiate(mobs[currentType], spawn.position, Quaternion.identity);
				AddTagRecursively(mobclone.transform, gameObject.tag);
				NavMeshAgent nMesh = mobclone.GetComponent<NavMeshAgent>();
				nMesh.destination = destination.position;
				startTimer = 0;
				currentType++;
				if(currentType >= mobs.Count){
					currentType = 0;
				}
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
