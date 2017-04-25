using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour {
	public string constructName;
	public string constructDescription;
	public ConsumableScriptableObject upgrades;

	GameManager gameManager;

	public virtual void useItem(WorldPart partLinked){}
	public virtual bool canBeUse(WorldPart partLinked){return true;}
	public bool haveEnoughtResources(){
		gameManager = GameManager.instance;
		return upgrades.mainConstructUpgrades[0].upgradeWoodCost <= gameManager.getWood()
		&& upgrades.mainConstructUpgrades[0].upgradeMineralCost <= gameManager.getMineral()
		&& upgrades.mainConstructUpgrades[0].upgradeGemCost <= gameManager.getGem()
		&& upgrades.mainConstructUpgrades[0].upgradeOxygenCost <= gameManager.getOxygen();
	}

	public void payItem(){
		gameManager.consumneWood(upgrades.mainConstructUpgrades[0].upgradeWoodCost);
		gameManager.consumneMineral(upgrades.mainConstructUpgrades[0].upgradeMineralCost);
		gameManager.consumneGem(upgrades.mainConstructUpgrades[0].upgradeGemCost);
		gameManager.consumneOxygen(upgrades.mainConstructUpgrades[0].upgradeOxygenCost);
	}
	public int getWoodCost(){
		return upgrades.mainConstructUpgrades[0].upgradeWoodCost;
	}
	public int getOxygenCost(){
		return upgrades.mainConstructUpgrades[0].upgradeOxygenCost;
	}
	public int getMineralCost(){
		return upgrades.mainConstructUpgrades[0].upgradeMineralCost;
	}
	public int getGemCost(){
		return upgrades.mainConstructUpgrades[0].upgradeGemCost;
	}
	public int getEnergyCost(){
		return upgrades.mainConstructUpgrades[0].energyCost;
	}

}
