using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnScript : MonoBehaviour {

    public Transform playerSpawnPoint;

	// Use this for initialization
	void OnEnable () {
        gameObject.transform.position = playerSpawnPoint.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
