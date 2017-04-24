using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour {
	
	WorldPart actualPart;
	WorldPartUI worldPartUI;

	public GameObject selectedPart;

	public void setActualPart(GameObject actualPartObject){
		if(actualPart != null){
			undisplayPartMenu();
		}
		this.actualPart = actualPartObject.GetComponent<WorldPart>();
		updateFeedbackPart ();
		this.worldPartUI = actualPartObject.GetComponent<WorldPartUI>();
		displayBuilderMenu();
	}

	public void updateFeedbackPart(){
	//animation du ground qui bouge
		actualPart.launchSelectedAnimation ();
	}

	public WorldPart getActualPart(){
		return actualPart;
	}

	private void undisplayPartMenu(){
		actualPart.stopSelectedAnimation ();
		worldPartUI.undisplayInterface();
	}

	public void displayBuilderMenu(){
		worldPartUI.undisplayInterface();
		if(actualPart.mainConstruct.name != "Empty"){
			worldPartUI.displayInterfaceMain(actualPart.mainConstruct.canBeUpgraded());
		}

		if(actualPart.secondaryConstruct.name != "Empty"){
			worldPartUI.displayInterfaceSecondary(actualPart.secondaryConstruct.canBeReapair());
		}
	}

	public void upgrade(){
		actualPart.mainConstruct.upgrade();
	}

	public void remove(){
		actualPart.removeMainConstruct();
	}

	public void repair(){
		actualPart.secondaryConstruct.repair();
	}

	public void removeSecondary(){
		actualPart.removeSecondaryConstruct();
	}

	private static Builder s_Instance = null;

    // This defines a static instance property that attempts to find the manager object in the scene and
    // returns it to the caller.
    public static Builder instance
    {
        get
        {
            if (s_Instance == null)
            {
                // This is where the magic happens.
                //  FindObjectOfType(...) returns the first AManager object in the scene.
                s_Instance = FindObjectOfType(typeof(Builder)) as Builder;
            }

            // If it is still null, create a new instance
            if (s_Instance == null)
            {
                GameObject obj = Instantiate(Resources.Load("Builder") as GameObject);
                s_Instance = obj.GetComponent<Builder>();
            }
            return s_Instance;
        }
	}
}
