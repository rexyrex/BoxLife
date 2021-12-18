using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statBonus {
	public int BonusValue {
		get;
		set;
	}

	public statBonus (int bonusValue){
		this.BonusValue = bonusValue;
		Debug.Log ("A new stat bonus!!");
	}

}
