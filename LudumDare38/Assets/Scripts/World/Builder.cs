using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour {
	WorldPart actualPart;
	WorldPartUI worldPartUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setActualPart(GameObject actualPartObject){
		if(actualPart != null){
			undisplayPartMenu();
		}
		this.actualPart = actualPartObject.GetComponent<WorldPart>();
		this.worldPartUI = actualPartObject.GetComponent<WorldPartUI>();
		displayBuilderMenu();
	}

	public WorldPart getActualPart(){
		return actualPart;
	}

	private void undisplayPartMenu(){
		worldPartUI.undisplayInterface();
	}

	private void displayBuilderMenu(){
		worldPartUI.displayInterface();
		if(actualPart.mainConstruct.name != "Empty"){
			worldPartUI.displayInterface();
		}
			
		if(actualPart.secondaryConstruct.name == "Empty"){

		} else	{
			
		}
	}
}
