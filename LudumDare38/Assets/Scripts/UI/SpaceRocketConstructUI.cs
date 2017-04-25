using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceRocketConstructUI : MainConstructUI {

	void Awake(){
		builder = Builder.instance;
		mainContructComponent = mainContruct.GetComponent<MainConstruct>();

		buildName.text = mainContructComponent.constructName;
		description.text = mainContructComponent.constructDescription;

		buildOxygenCost.text = "50/d";
		buildWoodCost.text = mainContructComponent.getWoodCost().ToString();;
		buildMineralCost.text = mainContructComponent.getMineralCost().ToString();;
		buildEnergyCost.text = mainContructComponent.getEnergyCost() + "/d";
		buildGemCost.text = mainContructComponent.getGemCost().ToString();

		buildOxygenProduction.text = mainContructComponent.getOxygenProduction() + "/d";
		buildWoodProduction.text = mainContructComponent.getWoodProduction() + "/d";
		buildMineralProduction.text = mainContructComponent.getMineralProduction() + "/d";
		buildEnergyProduction.text = mainContructComponent.getEnergieProduction() + "/d";
		buildGemProduction.text = mainContructComponent.getGemProduction() + "/d";
	}

	public override void instantiate(){
		if(builder.getActualPart().canMainConstruct()){
			if(mainContructComponent.haveEnoughtResources()){
				builder.getActualPart().addMainConstruct(mainContruct);
			}
		}
	}
}
