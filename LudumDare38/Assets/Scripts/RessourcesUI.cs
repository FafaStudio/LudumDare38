using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourcesUI : MonoBehaviour {
	public Text oxygenDisplay;
	public Text oxygenAugmentDisplay;
	public Text woodDisplay;
	public Text woodAugmentDisplay;
	public Text mineralDisplay;

	public Text mineralAugmentDisplay;
	public Text energyDisplay;
	public Text energyAugmentDisplay;
	public Text gemDisplay;
	public Text gemAugmentDisplay;

	public GameManager gameManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		oxygenDisplay.text = "" + gameManager.getOxygen();
		setAugment(oxygenAugmentDisplay, gameManager.worldController.getDayOxygenProduct()/gameManager.getDayDuration());

		woodDisplay.text = "" + gameManager.getWood();
		setAugment(woodAugmentDisplay, gameManager.worldController.getDayWoodProduct()/gameManager.getDayDuration());

		mineralDisplay.text = "" + gameManager.getMineral();
		setAugment(mineralAugmentDisplay, gameManager.worldController.getDayMineralProduct()/gameManager.getDayDuration());

		energyDisplay.text = "" + gameManager.getEnergy();
		setAugment(energyAugmentDisplay, gameManager.worldController.getDayEnergieProduct()/gameManager.getDayDuration());

		gemDisplay.text = "" + gameManager.getGem();
		setAugment(gemAugmentDisplay, gameManager.worldController.getDayGemProduct()/gameManager.getDayDuration());
	}

	private void setAugment(Text text, float value){
		if(value > 0){
			text.text = "+" + value + "/s";
			text.color = Color.green;
		}	else	if(value ==0){
			text.text = "";
			text.color = Color.green;
		}	else	{
			text.text = "" + value + "/s";
			text.color = Color.red;
		}
	}
}
