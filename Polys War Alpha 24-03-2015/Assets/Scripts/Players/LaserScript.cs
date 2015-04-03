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
								
								/*laser.enabled = true;	
								laser.SetPosition(1, hit.point);
								particle.Play ();
								*/
								
								GetComponent<NetworkView>().RPC("shotLaser", RPCMode.All, hit.point, eye.transform.position, cam.transform.rotation );

								if (hit.transform.name == PlayerTransform.name)
								GetComponent<NetworkView>().RPC("getHit", RPCMode.Others, WeaponDamage);

								if (hit.transform.tag == Score.enemy && hit.transform.gameObject.layer == 9 ){

									Mob m = hit.transform.GetComponent<Mob>();
									m.loseLife(2);
									
									}

							yield return null;
						}

		yield return new WaitForSeconds(0.4f);
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

		//NetworkViewID nEyeID = nEye.gameObject.GetComponent<NetworkViewID> ();

		Network.Destroy (nEye);
		/*
		LineRenderer lazer = Instantiate (laser, eye.transform.position, new Quaternion(0, 0, 0, 0)) as LineRenderer;
		lazer.SetPosition (0, eye.transform.position);
		lazer.enabled = true;	
		lazer.SetPosition(1, hit.point);
		*/

	}
	/*
	[RPC]
	void destroynEye(NetworkViewID nEyeID)
	{
		Destroy (nEyeID);
	}
*/




	/*[RPC]
	void Shoot(Vector3 start, Quaternion rotate)
	{
		Rigidbody instantiatedProjectile = Instantiate (projectile, new Vector3(start.x, start.y, start.z), rotate) as Rigidbody;
		instantiatedProjectile.velocity = transform.TransformDirection (new Vector3 (0, 0, speed));
	}*/

	/*[RPC]
	void sendShoot(Vector3 start, Quaternion rotate)
	{

		//NetworkView nView;
		Instantiate (projectile, start, rotate);
		//nView = projectile.GetComponent(NetworkView);

	}*/
}
