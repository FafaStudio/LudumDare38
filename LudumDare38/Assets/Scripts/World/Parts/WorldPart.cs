using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPart : MonoBehaviour {
	int index;
	
	public MainConstruct mainConstruct;
	public SecondaryConstruct secondaryConstruct;

	public MainConstruct mainEmptyConstruct;
	public SecondaryConstruct secondaryEmptyConstruct;
	public GameObject anchor;

	private Builder builder;
	private GameManager gameManager;

	private WorldController worldController;

	public GameObject eruptionParticleEffect;

	private AreaDetector areaDetector;

	int alienCounters = 0;
	int asteroideCounters = 0;
	int eruptionCounters = 0;
	int oxygenEmetors = 0;

	bool isSterile;
	bool isNormalySterile;
	bool isOccuped;

	bool isErupting;

	bool isAliened = false;

	GameObject alien;

	float oxygenMultiplicator;
	float woodMultiplicator;
	float mineralMultiplicator;
	float energieMultiplicator;
	float gemMultiplicator;

	Animator anim;

	void Awake () {
		builder = Builder.instance;
		gameManager = GameManager.instance;
		worldController = WorldController.instance;
		mainConstruct = mainEmptyConstruct;
		secondaryConstruct = secondaryEmptyConstruct;
		anim = GetComponent<Animator> ();
		eruptionParticleEffect.SetActive (false);
		areaDetector = GetComponentInChildren<AreaDetector>();
		//eruptionParticleEffect.GetComponent<ParticleSystem>().startLifetime += 
	}

	public void launchEruption(){
		if(eruptionCounters!=0){
			SoundManager.instance.launchSound ("eruptionRepulsed");
			return;
		}
		MusicManager.instance.launchBatuluPiste ();
		isErupting = true;
		eruptionParticleEffect.SetActive (true);
		SoundManager.instance.launchSound ("Eruption");
		GameManager.instance.addMenace (this.gameObject);
		eruptionParticleEffect.GetComponentInChildren<ParticleSystem> ().Play();
	}

	public void stopEruption(){
		if (!isErupting)
			return;
		isErupting = false;
		destroyConstruction ();
		GameManager.instance.removeMenace (this.gameObject);
		setIsSterile(true);
		eruptionParticleEffect.GetComponentInChildren<ParticleSystem> ().Stop();
		eruptionParticleEffect.SetActive (false);
	}

	public void interuptEruption(){
		isErupting = false;
		GameManager.instance.removeMenace (this.gameObject);
		SoundManager.instance.launchSound ("eruptionRepulsed");
		eruptionParticleEffect.GetComponentInChildren<ParticleSystem> ().Stop();
		eruptionParticleEffect.SetActive (false);
	}

	public void launchSelectedAnimation(){
		anim.SetBool ("isSelected", true);
	}

	public void stopSelectedAnimation(){
		anim.SetBool ("isSelected", false);
	}

	public bool canMainConstruct(){
		return mainConstruct.name == "Empty";
	}

	public bool canSecondaryConstruct(){
		return secondaryConstruct.name == "Empty";
	}

	public void addMainConstruct(GameObject mainConstruct){
		GameObject instance = Instantiate(mainConstruct, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 15), transform);
		this.mainConstruct = instance.GetComponent<MainConstruct>();
		instance.GetComponent<MainConstruct>().setPart (this);
		launchConstructionSound(instance.GetComponent<MainConstruct>());
		gameManager.consumneWood(this.mainConstruct.getWoodCost());
		gameManager.consumneMineral(this.mainConstruct.getMineralCost());
		gameManager.consumneGem(this.mainConstruct.getGemCost());
		builder.displayBuilderMenu();
		worldController.worldConstructs++;
		if(this.mainConstruct.constructName == "House"){
			worldController.setIsHomeBuild(true);
		}
		if(this.mainConstruct.constructName == "Power plant"){
			TutorialController.instance.nextIfPosition(12);
		}
		
		if(this.mainConstruct.constructName == "Aliencide diffuser"){
			TutorialController.instance.nextIfPosition(16);
		}
		MusicManager.instance.verifyPiste (worldController.worldConstructs);
	}

	public void upgradeMainConstruct(){
		if(!mainConstruct.canBeUpgraded()){
			return;
		}
		mainConstruct.upgrade();
		SoundManager.instance.launchSound ("upgradeMainUI");
		gameManager.consumneWood(this.mainConstruct.getWoodCost());
		gameManager.consumneMineral(this.mainConstruct.getMineralCost());
		gameManager.consumneGem(this.mainConstruct.getGemCost());
		builder.displayBuilderMenu();
	}

	public void launchConstructionSound(MainConstruct batiment){
		switch (batiment.categorie) {
		case MainConstruct.categorieBuilding.usine:
			SoundManager.instance.launchSound ("constructionUsine");
			break;
		case MainConstruct.categorieBuilding.defense:
			SoundManager.instance.launchSound ("constructionDefense");
			break;
		case MainConstruct.categorieBuilding.fusée:
			SoundManager.instance.launchSound ("constructionFusée");
			break;
		}
	}

	public void launchSecondaryConstructionSound(){
		SoundManager.instance.launchSound ("constructionSecondaire");
	}

	public void removeMainConstruct(){
		if(mainConstruct.constructName == "House"){
			worldController.setIsHomeBuild(false);
		}
		Destroy(mainConstruct.gameObject);
		mainConstruct = mainEmptyConstruct;
		builder.displayBuilderMenu();
		worldController.worldConstructs--;
		SoundManager.instance.launchSound ("removeMainUI");
		MusicManager.instance.GetComponent<MusicManager> ().verifyPiste (worldController.worldConstructs);
	}

	public void DestroyMainConstruct(){
		if(mainConstruct.constructName == "House"){
			worldController.setIsHomeBuild(false);
		}
		GameManager.instance.launchExplosion (mainConstruct.GetComponentInChildren<SpriteRenderer>().gameObject.transform.position);
		Destroy(mainConstruct.gameObject);
		mainConstruct = mainEmptyConstruct;
		builder.displayBuilderMenu();
		worldController.worldConstructs--;
		MusicManager.instance.GetComponent<MusicManager> ().verifyPiste (worldController.worldConstructs);
	}

	public void repairSecondaryConstruct(){
		if(!secondaryConstruct.canBeReapair()){
			return;
		}
		secondaryConstruct.repair();

		gameManager.consumneWood(this.secondaryConstruct.getWoodCost()/5);
		gameManager.consumneMineral(this.secondaryConstruct.getMineralCost()/5);
		gameManager.consumneGem(this.secondaryConstruct.getGemCost()/5);
		builder.displayBuilderMenu();
	}

	public void destroyConstruction(){
		if (mainConstruct.constructName !="Empty") {
			DestroyMainConstruct ();
		}
		if (secondaryConstruct.constructName !="Empty") {
			destroySecondaryConstruct ();
		}
	}

	public void addSecondaryConstruct(GameObject secondaryConstruct){
		GameObject instance = Instantiate(secondaryConstruct, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 15), transform);
		this.secondaryConstruct = instance.GetComponent<SecondaryConstruct>();
		instance.GetComponent<SecondaryConstruct>().setPart (this);
		//launchConstructionSound(instance.GetComponent<SecondaryConstruct>());
		gameManager.consumneWood(this.secondaryConstruct.getWoodCost());
		gameManager.consumneMineral(this.secondaryConstruct.getMineralCost());
		gameManager.consumneGem(this.secondaryConstruct.getGemCost());
		launchSecondaryConstructionSound ();
		builder.displayBuilderMenu();
		worldController.worldConstructs++;
		MusicManager.instance.verifyPiste (worldController.worldConstructs);
	}

	public void destroySecondaryConstruct(){
		Destroy(secondaryConstruct.gameObject);
		secondaryConstruct = secondaryEmptyConstruct;
		builder.displayBuilderMenu();
	}

	public void removeSecondaryConstruct(){
		SoundManager.instance.launchSound ("removeMainUI");
		Destroy(secondaryConstruct.gameObject);
		secondaryConstruct = secondaryEmptyConstruct;
		builder.displayBuilderMenu();
	}

    public void setOxygenMultiplicator(float product){oxygenMultiplicator = product;}
	public void setWoodMultiplicator(float product){woodMultiplicator = product;}
	public void setMineralMultiplicator(float product){mineralMultiplicator = product;}
	public void setEnergieMultiplicator(float product){energieMultiplicator = product;}
	public void setGemMultiplicator(float product){gemMultiplicator = product;}

	public float getOxygenProduct(){
		if(isAliened){
			return -secondaryConstruct.getOxygenCost();
		}
		return oxygenMultiplicator * mainConstruct.getOxygenProduction() - secondaryConstruct.getOxygenCost() - mainConstruct.getOxygenCost();
	}
	public float getWoodProduct(){
		if(isAliened){
			return 0;
		}
		return woodMultiplicator * mainConstruct.getWoodProduction();
	}
	public float getMineralProduct(){
		if(isAliened){
			return 0;
		}
		return mineralMultiplicator * mainConstruct.getMineralProduction();
	}

	public float getEnergieProduct(){
		if(isAliened){
			return -mainConstruct.getEnergyCost() -secondaryConstruct.getEnergyCost();
		}
		return energieMultiplicator * mainConstruct.getEnergieProduction() - mainConstruct.getEnergyCost() - secondaryConstruct.getEnergyCost();
	}
	public float getGemProduct(){
		if(isAliened){
			return 0;
		}
		return gemMultiplicator * mainConstruct.getGemProduction() ;
	}

	public void setIsSterile(bool boolean){
		isSterile = boolean;

		if (isSterile) {
			sterilize ();
		} 	else	{
			dismissSterile();
		}
		isNormalySterile = isSterile;
	}

	public void tempIsSterile(bool boolean){
		isSterile = boolean;

		if (isSterile) {
			sterilize ();
		} 	else	{
			dismissSterile();
		}
	}

	public bool getIsSterile(){
		return isSterile;
	}

	public void sterilize(){
		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("MORTADELLE");
		StartCoroutine (startSterileMultiplicator ());
	}

	IEnumerator startSterileMultiplicator(){
		yield return new WaitForSeconds (0.5f);
		setSterileMultiplicator();
	}

	public bool getIsAliened(){
		return isAliened;
	}

	public void alienize(GameObject alien){
		this.isAliened = true;
		this.alien = alien;
		/*if (mainConstruct.name != "Empty") {
			mainConstruct.GetComponentInChildren<SpriteRenderer> ().color = new Color(0, 199, 241);
		}
		if (secondaryConstruct.name != "Empty") {
			secondaryConstruct.GetComponentInChildren<SpriteRenderer> ().color = new Color(0, 199, 241);
		}*/
	}

	public void unalienize(){
		/*if (mainConstruct.name != "Empty") {
			mainConstruct.GetComponentInChildren<SpriteRenderer> ().color = Color.white;
		}
		if (secondaryConstruct.name != "Empty") {
			secondaryConstruct.GetComponentInChildren<SpriteRenderer> ().color = Color.white;
		}*/
		this.isAliened = false;
		this.alien.GetComponent<AlienScript>().runAway();
		this.alien = null;
	}

	public bool getIsErupting(){
		return isErupting;
	}
	private void setSterileMultiplicator(){
		setOxygenMultiplicator(0.5f);
		setWoodMultiplicator(0.5f);
		setMineralMultiplicator(0.75f);
		setEnergieMultiplicator(0.75f);
		setGemMultiplicator(0);
	}

	public virtual void dismissSterile(){}
	public virtual void setMultiplicator(){}

	public bool isAlienProtected(){
		return alienCounters!=0;
	}

	public void addAlienCounter(){
		if(areaDetector.actualAlien != null){
			areaDetector.actualAlien.GetComponent<AlienScript>().runAway();
		}
		if(isAliened){
			unalienize();
		}
		alienCounters++;
	}
	public void removeAlienCounter(){
		alienCounters--;
	}
	public bool isAsteroideProtected(){
		return asteroideCounters!=0;
	}
	public void addAsteroideCounter(){
		if(areaDetector.actualAsteroid != null){
			areaDetector.actualAsteroid.GetComponent<Asteroid>().runAway();
		}
		asteroideCounters++;
	}
	public void removeAsteroideCounter(){
		asteroideCounters--;
	}

	public void addEruptionCounter(){
		if(isErupting){
			interuptEruption();
		}
		eruptionCounters++;
	}
	public void removeEruptionCounter(){
		eruptionCounters--;
	}

	public void addOxygenEmetors(){
		if(isSterile){
			tempIsSterile(false);
		}
		oxygenEmetors++;
	}

	public void removeOxygenEmetors(){
		oxygenEmetors--;
		if(oxygenEmetors == 0){
			if(isNormalySterile){
				tempIsSterile(true);
			}
		}
	}

	public void setIndex(int index){
		this.index = index;
	}

	public int getIndex(){
		return index;
	}
}
