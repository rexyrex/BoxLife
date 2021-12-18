using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	private GameObject slime;
	public GameObject spawnLocation;

	// Use this for initialization
	void Start () {
        slime = Resources.Load<GameObject> ("Enemies/Sapphiart_Sophie");
        //slime = Resources.Load<GameObject>("Enemies/Cha_Slime");
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.O)) {
			Debug.Log ("Spawning...");
			GameObject slimeInst = Instantiate (slime, spawnLocation.transform.position, spawnLocation.transform.rotation);

			//slimeInst.transform.position = spawnLocation.transform.position;

		}
	}
}
