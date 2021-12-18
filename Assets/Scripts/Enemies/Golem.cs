using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Golem : EnemyGeneric {

	public override void Start ()
	{
		base.Start ();
		name.text = "Golemmmm";
		//animator.SetTrigger ("SlimeHit");

	}
}
