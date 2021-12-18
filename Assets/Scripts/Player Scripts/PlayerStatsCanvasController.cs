using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsCanvasController : MonoBehaviour {

    public GameObject statsCanvas;
    public GameObject statsPanel;
    public GameObject resultPanel;
    public GameObject errorPanel;

    private Text errorText;

    //statsPanel Texts
    private Text nameLvl;
    private Text strengthText;
    private Text agilityText;
    private Text intelligenceText;
    private Text rexynessText;
    private Text pointsRemainingText;

    //resultPanel Texts
    private Text healthText;
    private Text powerText;
    private Text damageText;
    private Text critChanceText;
    private Text critDamageText;
    private Text experienceText;
    private Text expMultText;
    private Text armorText;
    private Text damageReductionText;
    private Text attractivenessText;

    //attributes
    private int strength;
    private int agility;
    private int intelligence;
    private int rexyness;
    private int power;

    //
    public static PlayerStatsCanvasController pscc;

    // Use this for initialization
    void Awake()
    {

            pscc = this;


        nameLvl = statsPanel.transform.Find("Title").GetComponent<Text>();
        strengthText = statsPanel.transform.Find("Strength").GetComponent<Text>();
        agilityText = statsPanel.transform.Find("Agility").GetComponent<Text>();
        intelligenceText = statsPanel.transform.Find("Intelligence").GetComponent<Text>();
        rexynessText = statsPanel.transform.Find("Rexyness").GetComponent<Text>();
        pointsRemainingText = statsPanel.transform.Find("Points_Remaining").GetComponent<Text>();

        healthText = resultPanel.transform.Find("Health").GetComponent<Text>();
        powerText = resultPanel.transform.Find("Power").GetComponent<Text>();
        damageText = resultPanel.transform.Find("Damage").GetComponent<Text>();
        critChanceText = resultPanel.transform.Find("CritChance").GetComponent<Text>();
        critDamageText = resultPanel.transform.Find("CritDamage").GetComponent<Text>();
        experienceText = resultPanel.transform.Find("Experience").GetComponent<Text>();
        expMultText = resultPanel.transform.Find("ExpMult").GetComponent<Text>();
        armorText = resultPanel.transform.Find("Armor").GetComponent<Text>();
        damageReductionText = resultPanel.transform.Find("DamageReduction").GetComponent<Text>();
        attractivenessText = resultPanel.transform.Find("Attractiveness").GetComponent<Text>();

        errorText = errorPanel.transform.Find("ErrorText").GetComponent<Text>();
    }

    private void Start()
    {

    }

    public void applyPoints()
    {
        GlobalPlayerData.gpd.localStrIncVal = 0;
        GlobalPlayerData.gpd.localAgiIncVal = 0;
        GlobalPlayerData.gpd.localIntIncVal = 0;
        GlobalPlayerData.gpd.localRexyIncVal = 0;
        UpdateText();
    }

    public void resetPoints()
    {
        while((GlobalPlayerData.gpd.localStrIncVal + GlobalPlayerData.gpd.localAgiIncVal + GlobalPlayerData.gpd.localIntIncVal + GlobalPlayerData.gpd.localRexyIncVal) > 0)
        {
            if(GlobalPlayerData.gpd.localStrIncVal > 0)
            {
                RemoveStatBonus("Strength", 1);
                GlobalPlayerData.gpd.localStrIncVal--;
                GlobalPlayerData.gpd.statPoints++;
            }

            if (GlobalPlayerData.gpd.localAgiIncVal > 0)
            {
                RemoveStatBonus("Agility", 1);
                GlobalPlayerData.gpd.localAgiIncVal--;
                GlobalPlayerData.gpd.statPoints++;
            }

            if (GlobalPlayerData.gpd.localIntIncVal > 0)
            {
                RemoveStatBonus("Intelligence", 1);
                GlobalPlayerData.gpd.localIntIncVal--;
                GlobalPlayerData.gpd.statPoints++;
            }

            if (GlobalPlayerData.gpd.localRexyIncVal > 0)
            {
                RemoveStatBonus("Rexyness", 1);
                GlobalPlayerData.gpd.localRexyIncVal--;
                GlobalPlayerData.gpd.statPoints++;
            }            
        }
        UpdateText();
    }

    private bool notAllApplied()
    {
        return !((GlobalPlayerData.gpd.localStrIncVal + GlobalPlayerData.gpd.localAgiIncVal + GlobalPlayerData.gpd.localIntIncVal + GlobalPlayerData.gpd.localRexyIncVal) == 0);
    }
        


    private int getValue(string attribute)
    {
        /*for(int i=0; i<GlobalPlayerData.gpd.stats.Count; i++)
        {
            if(GlobalPlayerData.gpd.stats[i].StatName == attribute)
            {
                return GlobalPlayerData.gpd.stats[i].GetCalculatedStatValue();
            }

        }
        */
        foreach (baseStat bs in GlobalPlayerData.gpd.stats)
        {
            Debug.Log("checking stat name: " + bs.StatName);
            if (bs.StatName == attribute)
            {
                Debug.Log("Stat name is " + bs.StatName);
                return bs.GetCalculatedStatValue();
            }
        }

        return -999;


    }

    private void GetValues()
    {
        strength = getValue("Strength");
        agility = getValue("Agility");
        intelligence = getValue("Intelligence");
        rexyness = getValue("Rexyness");
        power = getValue("Power");
    }

    public void UpdateText()
    {
        nameLvl.text = "Rexyrex - Level " + GlobalPlayerData.gpd.level; 
        GetValues();
        if(GlobalPlayerData.gpd.localStrIncVal > 0)
        {
            strengthText.text = "Strength : (" + (strength - GlobalPlayerData.gpd.localStrIncVal) + " + " + GlobalPlayerData.gpd.localStrIncVal + ")";
            strengthText.color = Color.red;
        } else
        {
            strengthText.text = "Strength : " + strength;
            strengthText.color = Color.green;
        }

        if (GlobalPlayerData.gpd.localAgiIncVal > 0)
        {
            agilityText.text = "Agility : (" + (agility - GlobalPlayerData.gpd.localAgiIncVal) + " + " + GlobalPlayerData.gpd.localAgiIncVal + ")";
            agilityText.color = Color.red;
        }
        else
        {
            agilityText.text = "Agility : " + agility;
            agilityText.color = Color.green;
        }

        if (GlobalPlayerData.gpd.localIntIncVal > 0)
        {
            intelligenceText.text = "Intelligence : (" + (intelligence - GlobalPlayerData.gpd.localIntIncVal) + " + " + GlobalPlayerData.gpd.localIntIncVal + ")";
            intelligenceText.color = Color.red;
        }
        else
        {
            intelligenceText.text = "Intelligence : " + intelligence;
            intelligenceText.color = Color.green;
        }

        if (GlobalPlayerData.gpd.localRexyIncVal > 0)
        {
            rexynessText.text = "Rexyness : (" + (rexyness - GlobalPlayerData.gpd.localRexyIncVal) + " + " + GlobalPlayerData.gpd.localRexyIncVal + ")";
            rexynessText.color = Color.red;
        }
        else
        {
            rexynessText.text = "Rexyness : " + rexyness;
            rexynessText.color = Color.green;
        }

        pointsRemainingText.text = "Points to Spend : " + GlobalPlayerData.gpd.statPoints;


        //Result Panel Text Update
        healthText.text = "Health: " + GlobalPlayerData.gpd.currentHealth + "/" + GlobalPlayerData.gpd.maxHealth;
        powerText.text = "Power: " + power.ToString();
        damageText.text = "Damage: " + GlobalPlayerData.gpd.getMinDamage() + " - " + GlobalPlayerData.gpd.getMaxDamage();
        critChanceText.text = "Crit Chance: " + "TBD";
        critDamageText.text = "Crit Damage: " + "TBD";
        experienceText.text = "Experience: " + GlobalPlayerData.gpd.currentExperience + "/" + GlobalPlayerData.gpd.maxExperience;
        expMultText.text = "Experience Multiplier: " + GlobalPlayerData.gpd.experienceMultiplier.ToString();
        armorText.text = "Armor: " + "TBD";
        damageReductionText.text = "Damage Reduction: " + "TBD";
        attractivenessText.text = "Attractiveness:" + "UGLY AF";

        //Update health bars
        PlayerHealthBarScript.phbs.UpdateHealthBar();

    }


    public void decVal(string attribute)
    {
        //Dec
        {
            switch (attribute)
            {
                case "Strength":
                    if (GlobalPlayerData.gpd.localStrIncVal > 0)
                    {
                        RemoveStatBonus(attribute, 1);
                        GlobalPlayerData.gpd.statPoints++;
                        GlobalPlayerData.gpd.localStrIncVal--;
                    }
                    break;

                case "Intelligence":
                    if (GlobalPlayerData.gpd.localIntIncVal > 0)
                    {
                        RemoveStatBonus(attribute, 1);
                        GlobalPlayerData.gpd.statPoints++;
                        GlobalPlayerData.gpd.localIntIncVal--;
                    }
                    break;
                case "Agility":
                    if (GlobalPlayerData.gpd.localAgiIncVal > 0)
                    {
                        RemoveStatBonus(attribute, 1);
                        GlobalPlayerData.gpd.statPoints++;
                        GlobalPlayerData.gpd.localAgiIncVal--;
                    }
                    break;
                case "Rexyness":
                    if (GlobalPlayerData.gpd.localRexyIncVal > 0)
                    {
                        RemoveStatBonus(attribute, 1);
                        GlobalPlayerData.gpd.statPoints++;
                        GlobalPlayerData.gpd.localRexyIncVal--;
                    }
                    break;

                default: Debug.Log("NON attribute ERROR"); break;
            }
        }
        UpdateText(); //assume string is correct attribute
    }

    public void incVal(string attribute)
    {

        if (GlobalPlayerData.gpd.statPoints > 0)
        {
            switch (attribute)
            {
                case "Strength":
                    GlobalPlayerData.gpd.localStrIncVal++;
                    break;
                case "Intelligence":
                    GlobalPlayerData.gpd.localIntIncVal++;
                    break;
                case "Agility":
                    GlobalPlayerData.gpd.localAgiIncVal++;
                    break;
                case "Rexyness":
                    GlobalPlayerData.gpd.localRexyIncVal++;
                    break;
                default: Debug.Log("NON attribute ERROR"); break;
            }
            AddStatBonus(attribute, 1);
            GlobalPlayerData.gpd.statPoints--;
        }
        UpdateText();
    } 

    public void AddStatBonus(string attribute, int value)
    {
        foreach (baseStat bs in GlobalPlayerData.gpd.stats)
        {
            //Debug.Log("checking stat name: " + bs.StatName);
            if (bs.StatName == attribute)
            {
                //Debug.Log("Stat name is " + bs.StatName);
                bs.AddStatBonus(new statBonus(value));
                GlobalPlayerData.gpd.UpdatePlayerStats();
            }
        }
    }

    public void RemoveStatBonus(string attribute, int value)
    {
        foreach (baseStat bs in GlobalPlayerData.gpd.stats)
        {
            //Debug.Log("checking stat name: " + bs.StatName);
            if (bs.StatName == attribute)
            {
                //Debug.Log("Stat name is " + bs.StatName);
                bs.RemoveStatBonus(new statBonus(value));
                GlobalPlayerData.gpd.UpdatePlayerStats();
            }
        }
    }

    public void applyAndContinue()
    {
        applyPoints();
        Time.timeScale = 1.0f;
        statsCanvas.SetActive(false);
        errorPanel.SetActive(false);
    }

    public void goBack()
    {
        errorPanel.SetActive(false);
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            if(statsCanvas.activeSelf == true)
            {
                //Turn Off
                if (notAllApplied())
                {
                    errorPanel.SetActive(true);
                    errorText.text = "You have assigned but not applied some points! Continuing will apply your assigned points";
                    //Buttons: Continue, Back
                } else if (GlobalPlayerData.gpd.statPoints > 0)
                {
                    errorPanel.SetActive(true);
                    errorText.text = "You have not used all of your points! Continue?";
                    //Buttons: Continue, Back
                } else
                {
                    Time.timeScale = 1.0f;
                    statsCanvas.SetActive(false);
                }
            }else
            {
                //Turn On
                UpdateText();
                Time.timeScale = 0.0f;
                statsCanvas.SetActive(true);
            }
            /*
            if (statsPanel.activeSelf == true)
            {
                Time.timeScale = 1.0f;
                statsPanel.SetActive(false);
            }else
            {
                Time.timeScale = 0.0f;

                statsPanel.SetActive(true);
            }
            if (resultPanel.activeSelf == true)
            {
                Time.timeScale = 1.0f;
                resultPanel.SetActive(false);
            }
            else
            {
                Time.timeScale = 0.0f;
                resultPanel.SetActive(true);
            }*/

        }
	}
}
