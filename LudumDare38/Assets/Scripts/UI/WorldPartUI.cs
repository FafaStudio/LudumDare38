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
	public Image logoDefense;

	public List<WorldPartUI> listVoisinDefense = new List<WorldPartUI>();

	
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
		buildingPartInterface.gameObject.SetActive(true);
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

	public void remove(){
		builder.remove();
	}

	public void repair(){
		builder.repair();
	}

	public void removeSecondary(){
		builder.removeSecondary();
	}

	public void displayLogoDefense(WorldPart linkedPart){
		buildingPartInterface.gameObject.SetActive(true);
		if(linkedPart.secondaryConstruct.constructName == "Alienicide module" || linkedPart.secondaryConstruct.constructName == "Asteroid Umbrella" || linkedPart.secondaryConstruct.constructName == "Counter choc"){
			listVoisinDefense.Add(this);
		}
		if(linkedPart.mainConstruct.constructName == "Aliencide diffuser" || linkedPart.mainConstruct.constructName == "Forcefield" || linkedPart.mainConstruct.constructName == "Earthquake maker"){
			listVoisinDefense.Add(this);
			int newIndex = linkedPart.getIndex()+1;
			if (newIndex>=24){
				newIndex = newIndex-24;
			}
			listVoisinDefense.Add(WorldController.instance.worldParts[newIndex].GetComponent<WorldPartUI>());

			newIndex = linkedPart.getIndex()-1;
			if (newIndex<0){
				newIndex = 24 + newIndex;
			}
			listVoisinDefense.Add(WorldController.instance.worldParts[newIndex].GetComponent<WorldPartUI>());
		}
		foreach (WorldPartUI item in listVoisinDefense)
		{
			item.buildingPartInterface.gameObject.SetActive(true);
			item.logoDefense.gameObject.SetActive(true);
		}
	}

	public void undisplayLogoDefense(){

		foreach (WorldPartUI item in listVoisinDefense)
		{
			item.buildingPartInterface.gameObject.SetActive(false);
			item.logoDefense.gameObject.SetActive(false);
		}
		listVoisinDefense = new List<WorldPartUI>();
	}
}
