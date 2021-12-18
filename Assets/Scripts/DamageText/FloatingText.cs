using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {
	public Animator animator;
	private Text damageText;


	// Use this for initialization
	void OnEnable () {
		AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo (0);
		Destroy (gameObject, clipInfo [0].clip.length);
		damageText = animator.GetComponent<Text> ();
	
	}

	public void SetText(string damageText){
		this.damageText.text = damageText;
	}

	public void SetTextColor(Color c){
		//Debug.Log ("color set to " + c.ToString());
		this.damageText.color = c;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
