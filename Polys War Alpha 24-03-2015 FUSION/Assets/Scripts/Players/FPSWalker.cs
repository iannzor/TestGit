using UnityEngine;
using System.Collections;

public class FPSWalker : MonoBehaviour {
	
		public float jumpSpeed = 8F;
		public float speed = 6F;
		public float gravity = 20F;
		
		public CollisionFlags flags;
	
		public CharacterController controller;	

		private Vector3 moveDirection = Vector3.zero;

		private bool grounded = false;
		

	
	void Start()
	{	/*
		if (GetComponent<NetworkView>().isMine == false){ 

			gameObject.GetComponent<FPSWalker>().enabled  = false;
			gameObject.GetComponent<MouseLook>().enabled  = false;
			gameObject.GetComponentInChildren<LaserScript>().enabled = false;
			gameObject.GetComponentInChildren<Camera>().enabled = false; 
			gameObject.GetComponentInChildren<GUILayer>().enabled = false;
			gameObject.GetComponentInChildren<AudioListener>().enabled = false;
			gameObject.GetComponentInChildren<MouseLook>().enabled = false;
			gameObject.GetComponentInChildren<InitiateOnClick>().enabled = false;

			//gameObject.GetComponentInChildren<NetworkView>().enabled = false;
		}
*/
	}
	
	void FixedUpdate() {
				//if (networkView.isMine) {
						if (grounded) {
								// Au sol -> donc re-calculer movedirection directement depuis les axes
								moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
								moveDirection = transform.TransformDirection (moveDirection);
								moveDirection *= speed;
				
								if (Input.GetButton ("Jump")) {
										moveDirection.y = jumpSpeed;
								}
						}
			
						// Appliquer la gravité
						moveDirection.y -= gravity * Time.deltaTime;
			
						// Bouger le controller
			
						flags = controller.Move (moveDirection * Time.deltaTime);
						grounded = (flags & CollisionFlags.CollidedBelow) != 0;
				//}
		}
		
		/*void Awake ()	{
	public CharacterController controller = GetComponent(CharacterController);
	if (!controller)
		gameObject.AddComponent("CharacterController");
	}*/
		
}