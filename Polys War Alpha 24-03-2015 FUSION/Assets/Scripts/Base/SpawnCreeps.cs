using UnityEngine;
using System.Collections;

public class SpawnCreeps : MonoBehaviour {

	public float interval = 3.0f;
	float timeLeft = 0.0f;
	//public int HPmob = 100;
	public static GameObject mobclone = null;
	public GameObject mob = null;


	public Transform destination = null;
	
	
	// Update is called once per frame
	void Update () {
		// time to spawn the next one?

		if(Network.isServer && Score.ready == true){
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0.0f) {
			
			mobclone = Network.Instantiate(mob, transform.position, Quaternion.identity, 0) as GameObject;

			NavMeshAgent nMesh = mobclone.GetComponent<NavMeshAgent>();
			
			nMesh.destination = destination.position;

			timeLeft = interval;
			}
		}




	}
}
