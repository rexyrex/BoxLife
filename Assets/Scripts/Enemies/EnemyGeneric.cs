using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class EnemyGeneric : MonoBehaviour, IEnemy {

	public Animator animator;
	protected Image healthBar;
	protected float timeSinceLastHit;
	protected bool isHit;
	protected Image healthCanvas;
	protected Text name;
	protected NavMeshAgent navAgent;
	protected GameObject navTarget;
	protected int currentHealth;
	public int maxHealth;
	public float minDamage;
	public float maxDamage;
	public float experience;

    protected bool isAggro;
    

    // Use this for initialization
    public virtual void Start()
    {
        currentHealth = maxHealth;

        healthBar = transform.Find("EnemyCanvas").Find("HealthBG").Find("Health").GetComponent<Image>();
        healthCanvas = transform.Find("EnemyCanvas").Find("HealthBG").GetComponent<Image>();
        name = transform.Find("EnemyCanvas").Find("Name").GetComponent<Text>();

        navTarget = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent<NavMeshAgent>();

        hideHealthBars();
        timeSinceLastHit = 4;
        isHit = false;
        isAggro = false;
    }

    public virtual void TakeDamage (int amount)
	{
        //Dealing with hits for Health bar hiding etc
        isHit = true;
		timeSinceLastHit = 0;

		//Remember to set Animator.SetTrigger("xxx") in child class
		animator.enabled = true;

		currentHealth -= amount;

		//Update Health Bar
		healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
		if (currentHealth <= 0) {
			Die ();
		}

	}

	public virtual void PerformAttack ()
	{
		
	}

	public virtual float getDamage(){
		return Random.Range (minDamage, maxDamage);
	}


	private void hideHealthBars(){
		name.rectTransform.localPosition = new Vector3(0,-8,0);
		healthCanvas.enabled = false;
		healthBar.enabled = false;
	}

	private void showHealthBars(){
		name.rectTransform.localPosition = new Vector3(0,5,0);
		healthCanvas.enabled = true;
		healthBar.enabled = true;
	}

	public virtual void Die(){
		GlobalPlayerData.gpd.UpdateExperience ((int)experience);
		PlayerHealthBarScript.phbs.UpdateHealthBar ();
        
        Destroy (gameObject);
	}



	public virtual void followPlayer(){
		if (isHit) {
			//Debug.Log ("IS hit!");
			showHealthBars ();
			navAgent.destination =  (navTarget.transform.position);
		} else {
			hideHealthBars ();
            navAgent.ResetPath();
		}

	}

	public virtual bool isMoving(){
		if (!navAgent.pathPending)
		{
			if (navAgent.remainingDistance <= navAgent.stoppingDistance)
			{
				if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
				{
					return false;
				}
			}
		}
		return true;
	}

    public virtual bool isInAttackRange()
    {
        if(Vector3.Distance(transform.position, navTarget.transform.position) < 3)
        {
            return true;
        } else
        {
            return false;
        }
    }

	// Update is called once per frame
	public virtual void Update () {

        Vector3 direction = navTarget.transform.position - transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        //temp disabled angle check

		if (timeSinceLastHit >= 3) {
			isHit = false;
		}

        if((    Vector3.Distance(transform.position, navTarget.transform.position) < 5) || isHit)
        {
            if (isHit)
            {
                //Debug.Log ("IS hit!");
                showHealthBars();
                navAgent.destination = (navTarget.transform.position);
                isAggro = true;
            }
            else
            {
                hideHealthBars();
            }
            navAgent.destination = (navTarget.transform.position);
            isAggro = true;
        } else
        {
            if (!isHit)
            {
                navAgent.ResetPath();
            }

        }
        

		timeSinceLastHit += Time.deltaTime;
	}
}
