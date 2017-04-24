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

	int alienCounters = 0;
	int asteroideCounters = 0;

	bool isSterile;
	bool isOccuped;

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
		//eruptionParticleEffect.GetComponent<ParticleSystem>().startLifetime += 
	}

	public void launchEruption(){
		eruptionParticleEffect.SetActive (true);
		eruptionParticleEffect.GetComponentInChildren<ParticleSystem> ().Play();
	}

	public void stopEruption(){
		destroyConstruction ();
		sterilize ();
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
		if(this.mainConstruct.constructName == "Home"){
			worldController.setIsHomeBuild(true);
		}
		MusicManager.instance.verifyPiste (worldController.worldConstructs);
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

	public void removeMainConstruct(){
		if(mainConstruct.constructName == "Home"){
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
		if(mainConstruct.constructName == "Home"){
			worldController.setIsHomeBuild(false);
		}
		Destroy(mainConstruct.gameObject);
		mainConstruct = mainEmptyConstruct;
		builder.displayBuilderMenu();
		worldController.worldConstructs--;
		MusicManager.instance.GetComponent<MusicManager> ().verifyPiste (worldController.worldConstructs);
	}

	public void destroyConstruction(){
		if (mainConstruct.constructName !="Empty") {
			DestroyMainConstruct ();
		}
		if (secondaryConstruct.constructName !="Empty") {
			removeSecondaryConstruct ();
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
		builder.displayBuilderMenu();
		worldController.worldConstructs++;
		MusicManager.instance.verifyPiste (worldController.worldConstructs);
	}

	public void removeSecondaryConstruct(){
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
		return oxygenMultiplicator * mainConstruct.getOxygenProduction() - secondaryConstruct.getOxygenCost();
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
		} 
	}

	public bool getIsSterile(){
		return isSterile;
	}

	public void sterilize(){
		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("MORTADELLE");
		setSterileMultiplicator();
	}


	public bool getIsAliened(){
		return isAliened;
	}
	public void alienize(GameObject alien){
		this.isAliened = true;
		this.alien = alien;
		print (mainConstruct.name);
		print (secondaryConstruct.name);
		/*if (mainConstruct.name != "Empty") {
			mainConstruct.GetComponentInChildren<SpriteRenderer> ().color = Color.grey;
		}
		if (secondaryConstruct.name != "Empty") {
			secondaryConstruct.GetComponentInChildren<SpriteRenderer> ().color = Color.grey;
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
		asteroideCounters++;
	}
	public void removeAsteroideCounter(){
		asteroideCounters--;
	}

	public void setIndex(int index){
		this.index = index;
	}

	public int getIndex(){
		return index;
	}
}
