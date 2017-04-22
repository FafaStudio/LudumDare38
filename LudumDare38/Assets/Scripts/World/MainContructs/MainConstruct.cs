using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainConstruct : MonoBehaviour
{
	public string constructName;
	public string constructDescription;
	int constructLevel = 0;

	[SerializeField]
	public MainConstructScriptableObject upgrades;

    // Use this for initialization
    void Awake()
    {
		
    }

    // Update is called once per frame
    void Update()
    {

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

	public int getOxygenMultiplicatorProduction(){
		return upgrades.mainConstructUpgrades[constructLevel].oxygenMultiplicatorProduction;
	}
	public int getWoodMultiplicatorProduction(){
		return upgrades.mainConstructUpgrades[constructLevel].woodMultiplicatorProduction;
	}
	public int getMineralMultiplicatorProduction(){
		return upgrades.mainConstructUpgrades[constructLevel].mineralMultiplicatorProduction;
	}
	public int getEnergieMultiplicatorProduction(){
		return upgrades.mainConstructUpgrades[constructLevel].energyMultiplicatorProduction;
	}
	public int getGemMultiplicatorProduction(){
		return upgrades.mainConstructUpgrades[constructLevel].gemMultiplicatorProduction;
	}

	public int getEnergyCost(){
		return upgrades.mainConstructUpgrades[constructLevel].energyCost;
	}
}
