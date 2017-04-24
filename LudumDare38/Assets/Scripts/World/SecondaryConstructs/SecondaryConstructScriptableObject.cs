using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryConstructScriptableObject : ScriptableObject {
	[SerializeField]
	public SecondaryConstructUpgrades secondaryConstructUpgrades;
}
[System.Serializable] 
public class SecondaryConstructUpgrades{
	public int buildWoodCost;
	public int buildMineralCost;
	public int buildGemCost;
	public int oxygenCost;
	public int energyCost;
}
