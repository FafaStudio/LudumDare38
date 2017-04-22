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

	int oxygenMultiplicator;
	int woodMultiplicator;
	int mineralMultiplicator;
	int energieMultiplicator;
	int gemMultiplicator;

	// Use this for initialization
	void Awake () {
		mainConstruct = mainEmptyConstruct;
		secondaryConstruct = secondaryEmptyConstruct;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addMainConstruct(MainConstruct mainConstruct){
		this.mainConstruct = mainConstruct;
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

    public void setOxygenMultiplicator(int product){oxygenMultiplicator = product;}
	public void setWoodMultiplicator(int product){woodMultiplicator = product;}
	public void setMineralMultiplicator(int product){mineralMultiplicator = product;}
	public void setEnergieMultiplicator(int product){energieMultiplicator = product;}
	public void setGemMultiplicator(int product){gemMultiplicator = product;}

	public int getOxygenProduct(){
		return oxygenMultiplicator * mainConstruct.getOxygenProduction() - secondaryConstruct.getOxygenCost();
	}
	public int getWoodProduct(){
		return woodMultiplicator * mainConstruct.getWoodProduction();
	}
	public int getMineralProduct(){
		return mineralMultiplicator * mainConstruct.getMineralProduction();
	}
	public int getEnergieProduct(){
		return energieMultiplicator * mainConstruct.getEnergieProduction() - mainConstruct.getEnergyCost() - secondaryConstruct.getEnergyCost();
	}
	public int getGemProduct(){
		return gemMultiplicator * mainConstruct.getGemProduction() ;
	}


	public void setIsSterile(bool boolean){isSterile = boolean;}

	public bool getIsSterile(){
		return isSterile;
	}
}
