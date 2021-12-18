using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Slime : EnemyGeneric{
	
	public override void Start ()
	{
		base.Start ();
		name.text = "Slime";

        

	}

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        AudioController.ac.playSound("hit", "slime");
        animator.SetTrigger("SlimeHit");
    }

    public override void Die()
    {
        base.Die();
        AudioController.ac.playSound("die", "slime");
    }

    public override void Update()
    {
        base.Update();
        if (isAggro)
        {
            if (isInAttackRange())
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", true);
            } else
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isAttacking", false);
            }
            
        }
    }
}
