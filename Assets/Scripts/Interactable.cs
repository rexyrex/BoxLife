using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {
	[HideInInspector]
	public NavMeshAgent playerAgent;
	private bool hasInteracted;

	public virtual void MoveToInteraction(NavMeshAgent playerAgent){
		hasInteracted = false;
		this.playerAgent = playerAgent;
		playerAgent.stoppingDistance = 2f;

		playerAgent.destination = this.transform.position;

	}	

	public virtual void AttemptInteraction(NavMeshAgent playerAgent){
		if (Vector3.Distance (playerAgent.transform.position, gameObject.transform.position) < 3) {
			Debug.Log ("Woooo we're in range!");
			Interact ();
			hasInteracted = true;
		} else {
			Debug.Log ("NOT IN RANGE");
		}
	}

	void Update(){
		/*if (playerAgent != null && !playerAgent.pathPending && !hasInteracted) {
			if(playerAgent.remainingDistance<= playerAgent.stoppingDistance){
				Interact ();
				hasInteracted = true;
			}
		}*/
	}

	public virtual void Interact(){
		Debug.Log ("Interacting with base class");
	}
	
}
