using UnityEngine;
using System.Collections;

public class InitiateOnClick : MonoBehaviour {
	
	Ray ray;
	RaycastHit hit;
	public GameObject prefab, prefabAttackZone, tower;
	public Vector3 whereToBuild = Vector3.zero;
	GameObject kube = null;
	public Material cantBuild, canBuild, built;
	public Texture2D crosshair, impossible;
	bool impossibleThere;
	//public SphereCollider radiusTower;

	
	
	// Use this for initialization
	void Start () {
		whereToBuild = new Vector3 (0.5f, 0.5f, 0f);
		OnTrigger.buildable = true;
		impossibleThere = false;


	}
	
	// Update is called once per frame
	
	void Update () {
		//if (networkView.isMine) {
		//ray = Camera.current.ScreenPointToRay(whereToBuild);
		ray = Camera.main.ViewportPointToRay (whereToBuild);	
		
		
		if (Physics.Raycast (ray, out hit, Mathf.Infinity, 1) && Score.gold >= 100) {   
			if (Input.GetKeyDown (KeyCode.Mouse1)) {
				
				//networkView.RPC ("KubeCreated", RPCMode.AllBuffered);
				//radiusTower.radius = 1f;
				kube = Instantiate (prefab, new Vector3 (hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
				
				
			}
			
			if (Input.GetKey (KeyCode.Mouse1)) {
				
				if (kube) {
					prefab.transform.position = new Vector3 (hit.point.x, prefab.GetComponent<Renderer>().bounds.size.y / 2, hit.point.z);
					prefab.transform.rotation = Quaternion.identity;
					
					kube.transform.position = new Vector3 (hit.point.x, prefab.GetComponent<Renderer>().bounds.size.y / 2, hit.point.z);
					//kube.renderer.bounds.size.y/2 permet d'obtenir la moitié de la hauteur de l'objet
					//kube.transform.position = new Vector3(hit.point.x,hit.point.y,hit.point.z);
					Debug.DrawLine (ray.origin, hit.point, Color.cyan, 0.1f);
					
					if (hit.transform.tag != Score.team )
						OnTrigger.buildable = false;
					
					if (OnTrigger.buildable == false) {
						kube.GetComponent<Renderer>().material = cantBuild;
						impossibleThere = true;
					} else {
						kube.GetComponent<Renderer>().material = canBuild;
						impossibleThere = false;
					}
				}
				
				
			}
			
			if (Input.GetKeyUp (KeyCode.Mouse1)) {
				
				if (hit.transform.tag != Score.team )
					Destroy (kube);
				
				if (OnTrigger.buildable == false) {
					Destroy (kube);
					OnTrigger.buildable = true;
					
				} else {
					if (kube)
						kube.GetComponent<Renderer>().material = built;

					prefab.transform.tag = Score.team;
					prefab.layer = 12;
					prefabAttackZone.transform.tag = Score.team;
					//GetComponent<NetworkView>().RPC("setTags", RPCMode.Others);
					Network.Instantiate(prefab, prefab.transform.position, prefab.transform.rotation, 0);


					Score.gold = Score.gold - 100;
					Destroy (kube);
					
					
					
				}
				impossibleThere = false;
			}
			
		} else {
			Destroy (kube);
		}
		//}
		
	}

	[RPC]
	void setTags()
	{
		prefab.transform.tag = Score.enemy;
		prefabAttackZone.transform.tag = Score.enemy;
	}

	
	void OnGUI()
	{
		float xMin = (Screen.width / 2) - (crosshair.width / 2);
		float yMin = (Screen.height / 2) - (crosshair.height / 2);
		GUI.DrawTexture(new Rect(xMin, yMin, crosshair.width, crosshair.height), crosshair);
		
		
		if(impossibleThere == true)
		{
			GUI.DrawTexture(new Rect((Screen.width / 2) - (impossible.width / 2), (Screen.height / 12) - (crosshair.height / 2), impossible.width, impossible.height), impossible);
		}
		
	}
}

