using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{
	//public Rigidbody projectile;
	//public float speed;
	Ray ray;
	RaycastHit hit;
	public GameObject laserSource;
	public Camera cam;
	public GameObject eye;
	Vector3 whereToShot = Vector3.zero;
	public ParticleSystem particle;
	bool canFire;
	int laserMask;

	public Texture2D crosshair;

	[SerializeField]
	Transform PlayerTransform;

	[SerializeField]
	float WeaponDamage;

	[SerializeField]
	LayersScript ls;

	[SerializeField]
	Player player;

	void Start()
	{
		whereToShot = new Vector3 (0.5f, 0.5f, 0f);
		canFire = true;
		Cursor.visible = false;
		
	}
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown("Fire1") && canFire == true)
		{
			Debug.Log(PlayerTransform.name);
			StopCoroutine("Fire");
			StartCoroutine("Fire");
		}
	}


	IEnumerator Fire()
	{
		ray = cam.ViewportPointToRay (whereToShot);

		if (Physics.Raycast (ray, out hit, Mathf.Infinity, ls.getLaserMask()))

						canFire = false;

						while (Input.GetButtonDown ("Fire1")) {
								
								
								GetComponent<NetworkView>().RPC("shotLaser", RPCMode.AllBuffered, hit.point, eye.transform.position, cam.transform.rotation );

								if (hit.transform.name == PlayerTransform.name)
								GetComponent<NetworkView>().RPC("getHit", RPCMode.Others, WeaponDamage);

								if (hit.transform.tag == Score.enemy && hit.transform.gameObject.layer == 9){
									Debug.Log (hit.transform);
									Mob m = hit.transform.GetComponent<Mob>();
									m.loseLife(20);
									
									}

							yield return null;
						}

		yield return new WaitForSeconds(0.3f);
		canFire = true;

	}


	[RPC]
	void getHit(float damages)
	{
		player.loseLife (damages);
	}
	

	[RPC]
	IEnumerator shotLaser(Vector3 endPosition, Vector3 startPosition, Quaternion camRotation)
	{

		GameObject nEye = Network.Instantiate(laserSource, startPosition, camRotation, 1) as GameObject;

		var lazer = nEye.gameObject.GetComponent<LineRenderer>();

		lazer.SetPosition(0, nEye.transform.position);
		lazer.enabled = true;
		lazer.SetPosition(1, endPosition);

		yield return new WaitForSeconds(0.1f);


		Network.Destroy (nEye);


	}

	void OnGUI()
	{
		float xMin = (Screen.width / 2) - (crosshair.width / 2);
		float yMin = (Screen.height / 2) - (crosshair.height / 2);
		GUI.DrawTexture(new Rect(xMin, yMin, crosshair.width, crosshair.height), crosshair);

		
	}

}
