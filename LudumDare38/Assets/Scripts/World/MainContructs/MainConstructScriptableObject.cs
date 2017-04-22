using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class MainConstructScriptableObject : ScriptableObject {
	[SerializeField]
	public List<MainConstructUpgrades> mainConstructUpgrades;
}
[System.Serializable] 
public class MainConstructUpgrades{
	public int oxygenBaseProduction;
    public int woodBaseProduction;
    public int mineralBaseProduction;
    public int energyBaseProduction;
    public int gemBaseProduction;

    public int oxygenMultiplicatorProduction;
    public int woodMultiplicatorProduction;
    public int mineralMultiplicatorProduction;
    public int energyMultiplicatorProduction;
    public int gemMultiplicatorProduction;
	public int upgradeWoodCost;
	public int upgradeMineralCost;
	public int upgradeGemCost;
	public int energyCost;
}
