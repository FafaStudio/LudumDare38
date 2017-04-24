using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour {
	public string constructName;
	public string constructDescription;
	public ConsumableScriptableObject upgrades;


	public virtual void useItem(WorldPart partLinked){}
	public virtual bool canBeUse(WorldPart partLinked){return true;}

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
