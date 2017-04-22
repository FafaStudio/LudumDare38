using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryConstructScriptableObject : ScriptableObject {
	[SerializeField]
	public List<SecondaryConstructUpgrades> secondaryConstructUpgrades;
}
[System.Serializable] 
public class SecondaryConstructUpgrades{
	public int upgradeWoodCost;
	public int upgradeMineralCost;
	public int upgradeGemCost;
	public int oxygenCost;
	public int energyCost;
}
