using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderWeapon : MonoBehaviour, IWeapon
{
    public List<baseStat> Stats
    {
        get;
        set;
    }

    public void PerformAttack()
    {
        AudioController.ac.playSound("swing", "player");
    }

    public void PerformSpecialAttack()
    {
        AudioController.ac.playSound("swing", "player");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
