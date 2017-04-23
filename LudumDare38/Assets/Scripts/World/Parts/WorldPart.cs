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

	bool isSterile;
	bool isOccuped;

	float oxygenMultiplicator;
	float woodMultiplicator;
	float mineralMultiplicator;
	float energieMultiplicator;
	float gemMultiplicator;

	void Awake () {
		mainConstruct = mainEmptyConstruct;
		secondaryConstruct = secondaryEmptyConstruct;
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
	}

	public void removeMainConstruct(){
		DestroyImmediate(mainConstruct.gameObject);
		mainConstruct = mainEmptyConstruct;
	}

	public void addSecondaryConstruct(SecondaryConstruct secondaryConstruct){
		this.secondaryConstruct = secondaryConstruct;
	}

	public void removeSecondaryConstruct(){
		DestroyImmediate(secondaryConstruct.gameObject);
		secondaryConstruct = secondaryEmptyConstruct;
	}

    public void setOxygenMultiplicator(float product){oxygenMultiplicator = product;}
	public void setWoodMultiplicator(float product){woodMultiplicator = product;}
	public void setMineralMultiplicator(float product){mineralMultiplicator = product;}
	public void setEnergieMultiplicator(float product){energieMultiplicator = product;}
	public void setGemMultiplicator(float product){gemMultiplicator = product;}

	public float getOxygenProduct(){
		return oxygenMultiplicator * mainConstruct.getOxygenProduction() - secondaryConstruct.getOxygenCost();
	}
	public float getWoodProduct(){
		return woodMultiplicator * mainConstruct.getWoodProduction();
	}
	public float getMineralProduct(){
		return mineralMultiplicator * mainConstruct.getMineralProduction();
	}
	public float getEnergieProduct(){
		return energieMultiplicator * mainConstruct.getEnergieProduction() - mainConstruct.getEnergyCost() - secondaryConstruct.getEnergyCost();
	}
	public float getGemProduct(){
		return gemMultiplicator * mainConstruct.getGemProduction() ;
	}


	public void setIsSterile(bool boolean){
		isSterile = boolean;
		if(isSterile){
			sterilize();
		}
	}

	public bool getIsSterile(){
		return isSterile;
	}
	public void sterilize(){
		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("MORTADELLE");
	}
	public virtual void dismissSterile(){

	}
}
