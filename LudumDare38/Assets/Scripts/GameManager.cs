using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	float oxygen;
	float wood;
	float mineral;
	float energy;
	float gem;

	public Texture2D cursorTexture;
	CursorMode cursorMode = CursorMode.ForceSoftware;
	Vector2 hotSpot = Vector2.zero;

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
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
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

	public float getOxygen(){
		return oxygen;
	}
	public float getWood(){
		return wood;
	}
	public float getMineral(){
		return mineral;
	}
	public float getEnergy(){
		return energy;
	}
	public float getGem(){
		return gem;
	}
	public int getDay(){
		return gameDay;
	}
}
