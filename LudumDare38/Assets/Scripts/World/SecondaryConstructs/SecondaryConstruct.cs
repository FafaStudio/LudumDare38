﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryConstruct : MonoBehaviour {
	public string constructName;
	public string constructDescription;
	int constructLevel = 0;

	int durability = 5;
	public int actualDurability = 5;

	GameManager gameManager;

	WorldPart partLinked;

	[SerializeField]
	public SecondaryConstructScriptableObject upgrades;

	public bool haveEnoughtResources(){
		gameManager = GameManager.instance;
		return upgrades.secondaryConstructUpgrades.buildWoodCost <= gameManager.getWood()
		&& upgrades.secondaryConstructUpgrades.buildMineralCost <= gameManager.getMineral()
		&& upgrades.secondaryConstructUpgrades.buildGemCost <= gameManager.getGem();
	}
	public void setPart(WorldPart part){
		partLinked = part;
	}
	public WorldPart getPart(){
		return partLinked;
	}

	public bool canBeReapair(){
		return this.actualDurability != durability;
	}

	public void repair(){
		actualDurability++;
	}

	public void useDurability(){
		actualDurability--;
		if(actualDurability == 0){
			partLinked.destroySecondaryConstruct();
		}
	}

	public int getEnergyCost(){
		return upgrades.secondaryConstructUpgrades.energyCost;
	}


	public int getOxygenCost(){
		return upgrades.secondaryConstructUpgrades.oxygenCost;
	}	
	
	public int getWoodCost(){
		return upgrades.secondaryConstructUpgrades.buildWoodCost;
	}
	public int getMineralCost(){
		return upgrades.secondaryConstructUpgrades.buildMineralCost;
	}
	public int getGemCost(){
		return upgrades.secondaryConstructUpgrades.buildGemCost;
	}
}
