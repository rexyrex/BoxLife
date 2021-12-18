using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarScript : MonoBehaviour {

	public Slider healthBar;
	public Slider expBar;
    public Text healthText;
    public Text expText;
    public Text nameAndLevelText;
    
	private float hasTakenDamageTimer = 0f;
    private bool tookDamage;

	public static PlayerHealthBarScript phbs;

    private void Awake()
    {
        phbs = this;
    }

    // Use this for initialization
    void Start () {
		FloatingTextController.Initialize ();

        //nameAndLevelText = expBar.transform.FindChild("NameAndText").GetComponent<Text>();
        UpdateHealthBar();
        tookDamage = false;
    }

	public void UpdateHealthBar(){
		healthBar.value = CalculatedHealth();
		expBar.value = CalculateExp ();
        healthText.text = "Health: [" + GlobalPlayerData.gpd.currentHealth + "/" + GlobalPlayerData.gpd.maxHealth + "]";
        expText.text = "Experience: [" + GlobalPlayerData.gpd.currentExperience + "/" + GlobalPlayerData.gpd.maxExperience + "]";
        nameAndLevelText.text = "ROXYROX, LEVEL 100";
	}

	public void TakeDamage(float damage){
        GlobalPlayerData.gpd.currentHealth -= damage;
		UpdateHealthBar ();
		if (GlobalPlayerData.gpd.currentHealth <= 0) {
			GlobalPlayerData.gpd.Die ();
		}
    }
	
	// Update is called once per frame
	void Update () {

		

        if (tookDamage)
        {
            hasTakenDamageTimer += Time.deltaTime; 
            if (hasTakenDamageTimer > 3)
            {
                tookDamage = false;
                hasTakenDamageTimer = 0;
            }
        }
	}

	float CalculatedHealth(){
		return GlobalPlayerData.gpd.currentHealth / GlobalPlayerData.gpd.maxHealth;
	}

	float CalculateExp(){
       
		return (float)(GlobalPlayerData.gpd.currentExperience) / (float)GlobalPlayerData.gpd.maxExperience;
	}
    
	//You have to add a rigidbody to the trigger object!!
	void OnTriggerEnter(Collider col){


        //FloatingTextController.CreatFloatingText (damage.ToString(), col.transform);
        if (col.tag == "Enemy" && tookDamage != true) {
			//Debug.Log ("player taking damage!");

			float damage = col.GetComponent<EnemyGeneric> ().getDamage ();
			FloatingTextController.CreatFloatingText (Mathf.Round(damage).ToString(), transform, Color.white);
			TakeDamage (damage);
            tookDamage = true;
		}
	}


}
