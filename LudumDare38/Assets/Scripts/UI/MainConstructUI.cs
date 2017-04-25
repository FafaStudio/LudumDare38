using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainConstructUI : MonoBehaviour {
	public Builder builder;
	public GameObject mainContruct;
	public MainConstruct mainContructComponent;
	public Text description;
	public Text buildName;
	public Text buildOxygenCost;
	public Text buildWoodCost;
	public Text buildMineralCost;
	public Text buildEnergyCost;
	public Text buildGemCost;
	public Text buildOxygenProduction;
	public Text buildWoodProduction;
	public Text buildMineralProduction;
	public Text buildEnergyProduction;
	public Text buildGemProduction;
	void Awake(){
		builder = Builder.instance;
		mainContructComponent = mainContruct.GetComponent<MainConstruct>();

		buildName.text = mainContructComponent.constructName;
		description.text = mainContructComponent.constructDescription;

		buildOxygenCost.text = "0";
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

	public virtual void instantiate(){
		if(builder.getActualPart().canMainConstruct()){
			if(mainContructComponent.haveEnoughtResources()){
				builder.getActualPart().addMainConstruct(mainContruct);
			}
		}
	}
}
