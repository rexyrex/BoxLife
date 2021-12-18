using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {
    
	public GameObject playerHand;
	public GameObject EquippedWeapon {
		get;
		set;
	}
	IWeapon equippedWeapon;

	CharacterStats characterStats;

	void Start(){
		characterStats = GetComponent<CharacterStats> ();
	}

	public void EquipWeapon(Item itemToEquip){
		if (EquippedWeapon != null) {
			characterStats.RemoveStatBonus (EquippedWeapon.GetComponent<IWeapon> ().Stats);
			Destroy (playerHand.transform.GetChild(0).gameObject);
		}
		EquippedWeapon = (GameObject)Instantiate (Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position,
			playerHand.transform.rotation);

		equippedWeapon = EquippedWeapon.GetComponent<IWeapon> ();
		equippedWeapon.Stats = itemToEquip.Stats;

		//EquippedWeapon.GetComponent<IWeapon> ().Stats = itemToEquip.Stats;
		EquippedWeapon.transform.SetParent (playerHand.transform);

		characterStats.AddStatBonus (itemToEquip.Stats);	
        
		Debug.Log ("Equippment Stats: "+ equippedWeapon.Stats[0].StatName +equippedWeapon.Stats [0].GetCalculatedStatValue());
        GlobalPlayerData.gpd.printPlayerStats();
	}

    public void UnEquipWeapon()
    {
        if (EquippedWeapon == null)
        {
            Debug.Log("Tried to unequip when no weapon equipped!");
        } else
        {
            characterStats.RemoveStatBonus(equippedWeapon.Stats);
            Destroy(EquippedWeapon);
            Debug.Log("Unequip successful!");
        }
    }

	public void PerformWeaponAttack(){
		equippedWeapon.PerformAttack ();
	}

	public void PerformWeaponSpecialAttack(){
		equippedWeapon.PerformSpecialAttack ();
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.X)){
			PerformWeaponAttack();
		}

		if(Input.GetKeyDown(KeyCode.Z)){
			PerformWeaponSpecialAttack();
		}

        
	}
}
