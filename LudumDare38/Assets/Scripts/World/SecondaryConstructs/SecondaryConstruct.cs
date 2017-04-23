using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryConstruct : MonoBehaviour {
	public string constructName;
	public string constructDescription;
	int constructLevel = 0;

	int durability = 5;
	int actualDurability = 5;

	[SerializeField]
	public SecondaryConstructScriptableObject upgrades;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool canBeReapair(){
		return this.actualDurability != durability;
	}

	public void repair(){
		
	}

	public int getEnergyCost(){
		return upgrades.secondaryConstructUpgrades[constructLevel].energyCost;
	}


	public int getOxygenCost(){
		return upgrades.secondaryConstructUpgrades[constructLevel].oxygenCost;
	}
}
