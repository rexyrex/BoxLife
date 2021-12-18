using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
	public List<baseStat> Stats { get; set; }
	public string ObjectSlug {
		get;
		set;
	}

	public Item(List<baseStat> _Stats, string _ObjectSlug){
		Stats = _Stats;
		ObjectSlug = _ObjectSlug;
	}

}
