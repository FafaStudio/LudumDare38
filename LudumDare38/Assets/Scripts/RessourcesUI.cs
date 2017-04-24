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
		oxygenDisplay.text = "" + Mathf.Floor(gameManager.getOxygen());
		setAugment(oxygenAugmentDisplay, gameManager.worldController.getDayOxygenProduct());

		woodDisplay.text = "" + Mathf.Floor(gameManager.getWood());
		setAugment(woodAugmentDisplay, gameManager.worldController.getDayWoodProduct());

		mineralDisplay.text = "" + Mathf.Floor(gameManager.getMineral());
		setAugment(mineralAugmentDisplay, gameManager.worldController.getDayMineralProduct());

		energyDisplay.text = "" + Mathf.Floor(gameManager.getEnergy());
		setAugment(energyAugmentDisplay, gameManager.worldController.getDayEnergieProduct());

		gemDisplay.text = "" + Mathf.Floor(gameManager.getGem());
		setAugment(gemAugmentDisplay, gameManager.worldController.getDayGemProduct());
	}

	private void setAugment(Text text, float value){
		if(value > 0){
			text.text = "+" + value + "/d";
			text.color = Color.green;
		}	else	if(value ==0){
			text.text = "";
			text.color = Color.green;
		}	else	{
			text.text = "" + value + "/d";
			text.color = Color.red;
		}
	}
}
