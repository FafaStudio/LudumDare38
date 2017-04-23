using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldPartUI : MonoBehaviour {
	private Builder builder;
	public Canvas buildingPartInterface;
	public Button upgradeButton;
	public Button removeButton;
	public Button repairButton;
	public Button removeButtonSecondary;
	
	void Awake(){
		builder = Builder.instance;
	}

	public void displayInterfaceMain(bool needUpgrade){
		buildingPartInterface.gameObject.SetActive(true);
		if(needUpgrade){
			upgradeButton.gameObject.SetActive(true);
		}
		removeButton.gameObject.SetActive(true);
	}
	public void displayInterfaceSecondary(bool needRepair){
		if(needRepair){
			repairButton.gameObject.SetActive(true);
		}
		removeButtonSecondary.gameObject.SetActive(true);
	}
	public void undisplayInterface(){
		buildingPartInterface.gameObject.SetActive(false);
		upgradeButton.gameObject.SetActive(false);
		removeButton.gameObject.SetActive(false);
		repairButton.gameObject.SetActive(false);
		removeButtonSecondary.gameObject.SetActive(false);
	}

	public void upgrade(){
		builder.upgrade();
	}

	public void remove(){
		builder.remove();
	}

	public void repair(){
		builder.repair();
	}

	public void removeSecondary(){
		builder.removeSecondary();
	}
}
