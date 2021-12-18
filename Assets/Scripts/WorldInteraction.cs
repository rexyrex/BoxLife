using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {

	NavMeshAgent playerAgent;
	//private Rigidbody rb;
	private bool isInteracting;
	public Animator animator;
	private bool isJumping;

	void GetInteraction(){
		isInteracting = true;
		Ray interactionRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit interactionInfo;

		if (Physics.Raycast (interactionRay, out interactionInfo, Mathf.Infinity)) {
			GameObject interactedObject = interactionInfo.collider.gameObject;
			if (interactedObject.tag == "Interactable Object") {
				Debug.Log ("Interactable Interacted!");
				//interactedObject.GetComponent<Interactable> ().MoveToInteraction(playerAgent);
				interactedObject.GetComponent<Interactable>().AttemptInteraction(playerAgent);
			} else {
				//playerAgent.stoppingDistance = 0f;
				//playerAgent.destination = interactionInfo.point;
			}
		}
	}

	// Use this for initialization
	void Start () {
		playerAgent = GetComponent<NavMeshAgent> ();
		//rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && 
			!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
			GetInteraction ();
			isInteracting = false;
		}
	}

	void FixedUpdate ()
	{
		float speed = 3;
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		//if (!playerAgent.pathPending) {
		//if (!isJumping) {
			playerAgent.destination = playerAgent.transform.position + movement;
		//}
		//}
		//rb.MovePosition (rb.position + speed*movement * Time.deltaTime);

		//rb.AddForce (movement * speed);

		/*if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("Jumping!" + rb.transform.position.y);

			animator.SetTrigger ("Jump");
			isJumping = true;
			playerAgent.enabled = false;
		} else {
			isJumping = false;
			playerAgent.enabled = true;
		}*/


	}

	public void jump(){
		//playerAgent.Stop ();

		
		//playerAgent.Stop ();
		isJumping = true;
		playerAgent.enabled = false;
		animator.SetTrigger ("Jump");
		/*rb.isKinematic = false;
		rb.useGravity = true;
		rb.AddForce (new Vector3 (0, 7, 0), ForceMode.Impulse);*/
	}
}