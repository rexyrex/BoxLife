using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour {

	private static FloatingText popupText;
	private static GameObject canvas;
	private static bool startedUpdating;
	private static FloatingText inst;
	private static Transform loc;

	public static void CreatFloatingText(string text, Transform location, Color c){
		FloatingText instance = Instantiate (popupText);

		Vector2 screenPosition = Camera.main.WorldToScreenPoint (location.position);

		instance.transform.SetParent (canvas.transform, false);
		instance.transform.position = screenPosition;

		//startUpdating (instance, location);
		instance.SetTextColor (c);
		instance.SetText (text);

	}

	public static void Initialize(){
		canvas = GameObject.Find ("DamageCanvas");
		popupText = Resources.Load<FloatingText> ("Prefabs/PopupText Parent");
	}

	// Use this for initialization
	void Start () {
		startedUpdating = false;
	}

	private static void startUpdating(FloatingText inst1, Transform loc1){
		startedUpdating = true;
		inst = inst1;
		loc = loc1;
		Debug.Log ("Started updating" + startedUpdating.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		/*if (startedUpdating) {
			Vector2 screenPosition = Camera.main.WorldToScreenPoint (loc.position);
			inst.transform.position = screenPosition;
			Debug.Log ("wooooohh");
		}
		Debug.Log("dqfuq");*/
	}
}
