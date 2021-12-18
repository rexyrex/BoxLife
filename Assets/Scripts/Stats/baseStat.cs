using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseStat {

	public List<statBonus> BaseAdditives {
		get;
		set;
	}

	public int BaseValue {
		get;
		set;
	}

	public string StatName {
		get;
		set;
	}

	public string StatDescription {
		get;
		set;
	}

	public int FinalValue{
		get;
		set;
	}

	public baseStat (int baseValue, string statName, string statDesc){
		this.BaseAdditives = new List<statBonus> ();
		this.BaseValue = baseValue;
		this.StatName = statName;
		this.StatDescription = statDesc;
	}
			
	public void AddStatBonus(statBonus statBonus){
		this.BaseAdditives.Add (statBonus);
	}

	public void RemoveStatBonus(statBonus statBonus){
		this.BaseAdditives.Remove(BaseAdditives.Find(x=>x.BonusValue == statBonus.BonusValue));
	}

	public int GetCalculatedStatValue(){
		this.FinalValue = 0;
		this.BaseAdditives.ForEach (x => this.FinalValue += x.BonusValue);
		FinalValue += BaseValue;
		return FinalValue;
	}

}
