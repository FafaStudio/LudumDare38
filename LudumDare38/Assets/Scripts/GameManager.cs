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
	float dayDuration = 120;
	float startLastDay;

	// Use this for initialization
	void Start () {
		oxygen = 10000;
		wood = 10000;
		mineral = 10000;
		energy = 10000;
		gem = 10000;
		startLastDay = Time.time;
		InvokeRepeating("getSecondeResources", 0, 1);
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
	//360 /dayDuration

	// Update is called once per frame
	void FixedUpdate () {
		if(Time.time - startLastDay >= dayDuration){
			//newDay();
			startLastDay = Time.time;
			gameDay++;
		}
	}

	public void getSecondeResources(){
		oxygen += worldController.getDayOxygenProduct()/dayDuration;
		wood += worldController.getDayWoodProduct()/dayDuration;
		mineral += worldController.getDayMineralProduct()/dayDuration;
		energy += worldController.getDayEnergieProduct()/dayDuration;
		gem += worldController.getDayGemProduct()/dayDuration;
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

	public void consumneOxygen(float value){
		oxygen-=value;
	}
	public void consumneWood(float value){
		wood-=value;
	}
	public void consumneMineral(float value){
		mineral-=value;
	}
	public void consumneEnergy(float value){
		energy-=value;
	}
	public void consumneGem(float value){
		gem-=value;
	}

	public void addOxygen(float val){
		oxygen += val;
	}
	public void addWood(float val){
		wood += val;
	}
	public void addMineral(float val){
		mineral += val;
	}
	public void addEnergy(float val){
		energy += val;
	}
	public void addGem(float val){
		gem += val;
	}

	public int getDay(){
		return gameDay;
	}

	public float getDayDuration(){
		return dayDuration;
	}

	public float getTimePassed(){
		return Time.time - startLastDay;
	}


	private static GameManager s_Instance = null;

    // This defines a static instance property that attempts to find the manager object in the scene and
    // returns it to the caller.
    public static GameManager instance
    {
        get
        {
            if (s_Instance == null)
            {
                // This is where the magic happens.
                //  FindObjectOfType(...) returns the first AManager object in the scene.
                s_Instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            }

            // If it is still null, create a new instance
            if (s_Instance == null)
            {
                GameObject obj = Instantiate(Resources.Load("GameManager") as GameObject);
                s_Instance = obj.GetComponent<GameManager>();
            }
            return s_Instance;
        }
	}
}
