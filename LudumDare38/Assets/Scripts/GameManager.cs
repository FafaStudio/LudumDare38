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

	List<GameObject> menace;

	int gameDay = 0;
	float dayDuration = 120;
	float startLastDay;

	public GameObject explosion;

	public GameObject gameOverPanel;
	public GameObject youWinPanel;

	void Start () {
		oxygen = 10000;
		wood = 10000;
		mineral = 10000;
		energy = 10000;
		gem = 10000;
		startLastDay = Time.time;
		InvokeRepeating("getSecondeResources", 0, 1);
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		gameOverPanel.SetActive (false);
		youWinPanel.SetActive (false);
		menace = new List<GameObject> ();
	}

	//360 /dayDuration
	void FixedUpdate () {
		checkGameOver ();
		verifyMenace ();
		if(Time.time - startLastDay >= dayDuration){
			//newDay();
			startLastDay = Time.time;
			if (worldController.getEruptionNumber ()!=0) {
				worldController.endEruption ();
			}
			SoundManager.instance.launchSound ("switchDay");
			SpaceSpawner.instance.trySpawnEruption ();
			gameDay++;
		}
	}

	public void addMenace(GameObject val){
		menace.Add (val);
	}
	public void removeMenace(GameObject val){
		menace.Remove (val);
		verifyMenace ();
	}

	public void verifyMenace(){
		if (menace.Count == 0) {
			MusicManager.instance.removeBatuluPiste ();
		}
	}

	public int getMenace(){
		return menace.Count;
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

	public void launchExplosion(Vector2 position){
		GameObject toInstantiate = Instantiate (explosion, position, Quaternion.identity) as GameObject;
		toInstantiate.transform.parent = this.transform;
		//toInstantiate.transform.parent = this.transform;
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
		checkGameOver ();
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

	public void checkGameOver(){
		if (energy <= 0) {
			energy = 0;
			gameOverPanel.SetActive (true);
		}
	}

	public void launchWinPanel(){
		youWinPanel.SetActive (true);
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
