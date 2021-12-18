using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
	public List<baseStat> stats = new List<baseStat>();
    /*
	 *	1. Power 
	 * 	2. Strength
	 * 	3. Intelligence
	 * 	4. Agility
	 * 	5. Rexyness
	 * 
	 */
    void Start(){

		//stats [0].AddStatBonus (new statBonus (5));
		if (gameObject.tag == "Player") {
			stats = GlobalPlayerData.gpd.stats;
		}


	}

	public void AddStatBonus(List<baseStat> statBonuses){
		foreach(baseStat statBonus in statBonuses){
			stats.Find (x=> x.StatName == statBonus.StatName).AddStatBonus(new statBonus(statBonus.BaseValue));
		}
	}

	public void RemoveStatBonus(List<baseStat> statBonuses){
		foreach(baseStat statBonus in statBonuses){
			stats.Find (x=> x.StatName == statBonus.StatName).RemoveStatBonus(new statBonus(statBonus.BaseValue));
		}
	}
}
