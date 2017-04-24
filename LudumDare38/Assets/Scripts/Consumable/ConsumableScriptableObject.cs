using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class ConsumableScriptableObject : ScriptableObject {
	[SerializeField]
	public List<ConsumableUpgrades> mainConstructUpgrades;
}
[System.Serializable] 
public class ConsumableUpgrades{
	public int upgradeOxygenCost;
	public int upgradeWoodCost;
	public int upgradeMineralCost;
	public int upgradeGemCost;
	public int energyCost;
}
