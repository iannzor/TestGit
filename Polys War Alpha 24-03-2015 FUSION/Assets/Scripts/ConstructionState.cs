using UnityEngine;
using System.Collections;

public class ConstructionState : MonoBehaviour {


	[SerializeField]
	InitiateOnClick constructionScript;

	[SerializeField]
	LaserScript shootScript;

	[SerializeField]
	BattleState timeToBattle;

	float timeLeft;

	bool reset;

	// Use this for initialization
	void OnEnable () {

		timeLeft = 0;


		if(GetComponent<NetworkView>().isMine == true){
			shootScript.enabled = false;
			constructionScript.enabled = true;
		}





	
	}
	
	// Update is called once per frame
	void Update () {

		timeLeft += Time.deltaTime;

		if (timeLeft >= 10f) {
			Debug.Log ("Time To Fight");
			timeToBattle.enabled = true;
			this.enabled = false;
		}

	
	}
}
