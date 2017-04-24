using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour {
	public Text tutoText;
	int tutorialPosition = 0;

	public TutorialScriptableObject tutorialTexts;

	void Awake(){
		changeText(tutorialTexts.listText[tutorialPosition]);
	}

	public void nextTuto(){
		tutorialPosition++;
		changeText(tutorialTexts.listText[tutorialPosition]);
	}

	public void changeText(string newText){
		tutoText.text = newText;
	}
	public void displayTutorial(){
		gameObject.SetActive(true);
	}

	public void hideTutorial(){
		gameObject.SetActive(false);
	}

	public bool isPosition(int pos){
		return tutorialPosition == pos;
	}
}
