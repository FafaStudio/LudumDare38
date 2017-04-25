using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumableUI : MonoBehaviour {
	public Builder builder;
	public GameObject mainContruct;
	Consumable mainContructComponent;
	public Text description;
	public Text buildName;
	public Text buildOxygenCost;
	public Text buildWoodCost;
	public Text buildMineralCost;
	public Text buildEnergyCost;
	public Text buildGemCost;
	void Awake(){
		builder = Builder.instance;
		mainContructComponent = mainContruct.GetComponent<Consumable>();

		buildName.text = mainContructComponent.constructName;
		description.text = mainContructComponent.constructDescription;

		buildOxygenCost.text = mainContructComponent.getOxygenCost().ToString();
		buildWoodCost.text = mainContructComponent.getWoodCost().ToString();;
		buildMineralCost.text = mainContructComponent.getMineralCost().ToString();;
		buildEnergyCost.text = mainContructComponent.getEnergyCost().ToString();
		buildGemCost.text = mainContructComponent.getGemCost().ToString();
	}

	public void instantiate(){
		if(mainContructComponent.haveEnoughtResources()){
			if(mainContructComponent.canBeUse(builder.getActualPart())){
				mainContructComponent.useItem(builder.getActualPart());
				mainContructComponent.payItem();
			}
		}
	}
}
