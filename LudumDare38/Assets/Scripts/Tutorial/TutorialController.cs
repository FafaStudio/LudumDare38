using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour {
	public Text tutoText;
	int tutorialPosition = 0;

	public GameObject menu;

	public TutorialScriptableObject tutorialTexts;

	void Awake(){
		changeText(tutorialTexts.listText[tutorialPosition].text);
	}

	public void nextTuto(){
		tutorialPosition++;
		if(tutorialPosition >= tutorialTexts.listText.Count){
			hideTutorial();
		}	else	{
			changeText(tutorialTexts.listText[tutorialPosition].text);
		}
		if(tutorialPosition == 5){
			menu.SetActive(true);
		}
		if(tutorialPosition == 13){
			SpaceSpawner.instance.spawnMenace ("Alien");
		}
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

	public void clickToNext(){
		if(!tutorialTexts.listText[tutorialPosition].waitActivation){
			nextTuto();
		}
	}

	public void nextIfPosition(int pos){
		if(isPosition(pos)){
			nextTuto();
		}
	}

	public bool isPosition(int pos){
		return tutorialPosition == pos;
	}

	private static TutorialController s_Instance = null;

    // This defines a static instance property that attempts to find the manager object in the scene and
    // returns it to the caller.
    public static TutorialController instance
    {
        get
        {
            if (s_Instance == null)
            {
                // This is where the magic happens.
                //  FindObjectOfType(...) returns the first AManager object in the scene.
                s_Instance = FindObjectOfType(typeof(TutorialController)) as TutorialController;
            }

            // If it is still null, create a new instance
            if (s_Instance == null)
            {
                GameObject obj = Instantiate(Resources.Load("TutorialController") as GameObject);
                s_Instance = obj.GetComponent<TutorialController>();
            }
            return s_Instance;
        }
	}
}
