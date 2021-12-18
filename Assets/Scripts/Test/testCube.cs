using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class testCube : MonoBehaviour {

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.isKinematic = false;
		rb.useGravity = true;
		rb.AddForce (new Vector3 (0, 8, 0), ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
