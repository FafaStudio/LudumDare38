using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainConstruct : MonoBehaviour
{
	public string constructName;
	public string constructDescription;
	int constructLevel = 0;

	public enum categorieBuilding{usine, secondaire, objet, fusée, defense};
	public categorieBuilding categorie;

	GameManager gameManager;

	WorldPart partLinked;

	[SerializeField]
	public MainConstructScriptableObject upgrades;

    // Use this for initialization
    void Awake()
    {
		gameManager = GameManager.instance;
    }

	public void setPart(WorldPart part){
		partLinked = part;
	}
	public WorldPart getPart(){
		return partLinked;
	}

	public bool haveEnoughtResources(){
		gameManager = GameManager.instance;
		return upgrades.mainConstructUpgrades[constructLevel].upgradeWoodCost <= gameManager.getWood()
		&& upgrades.mainConstructUpgrades[constructLevel].upgradeMineralCost <= gameManager.getMineral()
		&& upgrades.mainConstructUpgrades[constructLevel].upgradeGemCost <= gameManager.getGem();
	}

	public bool canBeUpgraded(){
		return upgrades.mainConstructUpgrades.Count > constructLevel;
	}

	public void upgrade(){

	}

	public int getOxygenProduction(){
		return upgrades.mainConstructUpgrades[constructLevel].oxygenBaseProduction;
	}
	public int getWoodProduction(){
		return upgrades.mainConstructUpgrades[constructLevel].woodBaseProduction;
	}
	public int getMineralProduction(){
		return upgrades.mainConstructUpgrades[constructLevel].mineralBaseProduction;
	}
	public int getEnergieProduction(){
		return upgrades.mainConstructUpgrades[constructLevel].energyBaseProduction;
	}
	public int getGemProduction(){
		return upgrades.mainConstructUpgrades[constructLevel].gemBaseProduction;
	}
	public int getWoodCost(){
		return upgrades.mainConstructUpgrades[constructLevel].upgradeWoodCost;
	}
	public int getMineralCost(){
		return upgrades.mainConstructUpgrades[constructLevel].upgradeMineralCost;
	}
	public int getGemCost(){
		return upgrades.mainConstructUpgrades[constructLevel].upgradeGemCost;
	}

	public int getEnergyCost(){
		return upgrades.mainConstructUpgrades[constructLevel].energyCost;
	}
}
