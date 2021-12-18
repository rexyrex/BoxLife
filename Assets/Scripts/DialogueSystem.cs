using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

	public string npcName;
	public GameObject dialoguePanel;

	Button continueButton;
	Text dialogueText, nameText;
	int dialogueIndex;
	private bool isDialogueActive;

	public static DialogueSystem Instance {
		get;
		set;
	}

	public List<string> dialogueLines = new List<string>();
	// Use this for initialization
	void Awake () {
		continueButton = dialoguePanel.transform.Find ("Continue").GetComponent<Button>();
		continueButton.onClick.AddListener (delegate {ContinueDialogue();});

		dialogueText = dialoguePanel.transform.Find ("Text").GetComponent<Text> ();
		nameText = dialoguePanel.transform.Find ("NamePanel").GetChild (0).GetComponent<Text> ();
		dialoguePanel.SetActive(false);

		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		} else {
			Instance = this;
		}
	}
	
	public void AddNewDialogue(string[] lines,string npcName){
		dialogueIndex = 0;
		dialogueLines = new List<string> (lines.Length);
		dialogueLines.AddRange (lines);
		this.npcName = npcName;
		CreateDialogue ();

	}

	public void CreateDialogue(){
		dialogueText.text = dialogueLines [dialogueIndex];
		nameText.text = npcName;
		dialoguePanel.SetActive (true);
		isDialogueActive = true;
	}

	public void ContinueDialogue(){
		if (dialogueIndex < dialogueLines.Count-1) {
			dialogueIndex++;
			dialogueText.text = dialogueLines [dialogueIndex];
		} else {
			isDialogueActive = false;
			dialoguePanel.SetActive (false);
		}
	}

	void Update(){
		if (isDialogueActive) {
			Time.timeScale = 0.0f;
		} else {
			Time.timeScale = 1.0f;
		}
	}
}
