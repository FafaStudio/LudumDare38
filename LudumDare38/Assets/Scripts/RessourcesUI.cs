using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourcesUI : MonoBehaviour {
	public Text oxygenDisplay;
	public Text woodDisplay;
	public Text mineralDisplay;
	public Text energyDisplay;
	public Text gemDisplay;

	public GameManager gameManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		oxygenDisplay.text = "Oxygen : " + gameManager.getOxygen();
		woodDisplay.text = "WhenWood : " + gameManager.getWood();
		mineralDisplay.text = "Mineral : " + gameManager.getMineral();
		energyDisplay.text = "Energy : " + gameManager.getEnergy();
		gemDisplay.text = "Gem : " + gameManager.getGem();
	}
}
