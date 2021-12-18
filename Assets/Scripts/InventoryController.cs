using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
	public PlayerWeaponController playerWeaponController;
	public Item Sword;

	void Start(){
		playerWeaponController = GetComponent<PlayerWeaponController> ();
		List<baseStat> swordStats = new List<baseStat> ();
		swordStats.Add (new baseStat(16, "Power","Your Power level"));
		Sword = new Item (swordStats,"Sword");
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.V)) {
			playerWeaponController.EquipWeapon (Sword);
		}
        if (Input.GetKeyDown(KeyCode.B))
        {
            playerWeaponController.UnEquipWeapon();
        }
	}
}
