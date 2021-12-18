using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPlayerData : MonoBehaviour {

	public static GlobalPlayerData gpd;

	public int level;
	private float minDamage;
	private float maxDamage;
	private float defaultDamage = 3;

	public float maxHealth;
	public float currentHealth;
	private float defaultHealth = 100f;

	public int maxExperience;
	public int currentExperience;
	public float experienceMultiplier = 1;

    public int statPoints;
    public int localStrIncVal;
    public int localAgiIncVal;
    public int localIntIncVal;
    public int localRexyIncVal;


	public List<baseStat> stats = new List<baseStat>();

	public float getMinDamage(){
		return minDamage;
	}

	public float getMaxDamage(){
		return maxDamage;
	}

	public void Die(){
		Debug.Log ("You are dead...");
	}

	void Awake () {
		if (gpd == null) {
			DontDestroyOnLoad (gameObject);
			gpd = this;
            setUpStats();
            UpdatePlayerStats();

		} else if(gpd != this){
			Destroy (gameObject);
		}
	}

    private void Start()
    {
        //PlayerStatsCanvasController.pscc.UpdateText();
    }

    void setUpStats()
    {
        statPoints = 12;
        stats.Add(new baseStat(4, "Power", "Your power level"));
        stats.Add(new baseStat(4, "Strength", "Your Strength"));
        stats.Add(new baseStat(4, "Intelligence", "Your Intelligence"));
        stats.Add(new baseStat(4, "Agility", "Your Agility"));
        stats.Add(new baseStat(7, "Rexyness", "Your sexiness"));
        level = 1;

        UpdatePlayerStats();
        currentHealth = maxHealth;
        printPlayerStats();
    }

	void OnEnable(){
        //player = GameObject.FindGameObjectWithTag ("Player");
        //cs = player.GetComponent<CharacterStats> ();

        //Change this so that cs is loaded or created on start screen


	}

    public void printPlayerStats()
    {
        foreach (baseStat bs in stats)
        {
            Debug.Log("Calculated value of " + bs.StatName + " is " + bs.GetCalculatedStatValue());
        }
    }

	public void UpdatePlayerStats(){
		//Power Affects Damage
		int power = stats [0].GetCalculatedStatValue();
		minDamage = defaultDamage + (int)(power/2);
		maxDamage = defaultDamage + power * 11.5f;

		//Strength Affects health
		int strength = stats [1].GetCalculatedStatValue();
		maxHealth = defaultHealth + strength * (10+level);

		//Intelligence Affects exp gain
		int intelligence = stats[2].GetCalculatedStatValue();
		experienceMultiplier = 1 + 0.07f * (float)intelligence;

        //Agility Affects Crits, armor

        //Rexyness Affects attractiveness


	}

	public void UpdateExperience(int experience){
		int experienceIncrease = (int)(experience * experienceMultiplier);
        //int experienceBeforeIncrease = currentExperience;
        
		currentExperience += experienceIncrease;
        Debug.Log("Updating EXP: " + currentExperience.ToString());
        if (currentExperience >= maxExperience) {
			currentExperience = currentExperience - maxExperience;
			LevelUp ();
		}

	}

	public void LevelUp(){
		level++;
	}
	

	void Update () {
		
	}
}
