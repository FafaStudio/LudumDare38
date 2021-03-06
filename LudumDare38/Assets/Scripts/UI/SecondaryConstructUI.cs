﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondaryConstructUI : MonoBehaviour {
	public Builder builder;
	public GameObject mainContruct;
	SecondaryConstruct mainContructComponent;
	public Text description;
	public Text buildName;
	public Text buildOxygenCost;
	public Text buildWoodCost;
	public Text buildMineralCost;
	public Text buildEnergyCost;
	public Text buildGemCost;
	void Awake(){
		builder = Builder.instance;
		mainContructComponent = mainContruct.GetComponent<SecondaryConstruct>();

		buildName.text = mainContructComponent.constructName;
		description.text = mainContructComponent.constructDescription;

		buildOxygenCost.text = mainContructComponent.getOxygenCost().ToString();
		buildWoodCost.text = mainContructComponent.getWoodCost().ToString();;
		buildMineralCost.text = mainContructComponent.getMineralCost().ToString();;
		buildEnergyCost.text = mainContructComponent.getEnergyCost().ToString();
		buildGemCost.text = mainContructComponent.getGemCost().ToString();
	}

	public void instantiate(){
		if(builder.getActualPart().canSecondaryConstruct()){
			if(mainContructComponent.haveEnoughtResources()){
				builder.getActualPart().addSecondaryConstruct(mainContruct);
			}
		}
	}
}
