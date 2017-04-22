using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	int oxygen;
	int wood;
	int mineral;
	int energy;
	int gem;

	public WorldController worldController;

	int gameDay = 0;
	float dayDuration = 5;
	float startLastDay;



	// Use this for initialization
	void Start () {
		oxygen = 0;
		wood = 0;
		mineral = 0;
		energy = 50;
		gem = 0;
		startLastDay = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Time.time - startLastDay >= dayDuration){
			newDay();
			startLastDay = Time.time;
			gameDay++;
		}
	}

	public void newDay(){
		oxygen += worldController.getDayOxygenProduct();
		wood += worldController.getDayWoodProduct();
		mineral += worldController.getDayMineralProduct();
		energy += worldController.getDayEnergieProduct();
		gem += worldController.getDayGemProduct();
	}

	public int getOxygen(){
		return oxygen;
	}
	public int getWood(){
		return wood;
	}
	public int getMineral(){
		return mineral;
	}
	public int getEnergy(){
		return energy;
	}
	public int getGem(){
		return gem;
	}
	public int getDay(){
		return gameDay;
	}
}
