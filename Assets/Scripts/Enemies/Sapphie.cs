using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapphie : EnemyGeneric {

	public override void Start ()
	{
		base.Start ();
		name.text = "Sapphie";


	}

	public override void TakeDamage (int amount)
	{
		base.TakeDamage (amount);
        AudioController.ac.playSound("hit", "sapphie");

	}

	public override void Update ()
	{
		base.Update ();
		/*if (isMoving ()) {
			animator.Play ("running");

		} else {
			animator.Play ("idle");
		}*/
	}

    public override void Die()
    {
        base.Die();
        AudioController.ac.playSound("die", "sapphie");
    }


}
