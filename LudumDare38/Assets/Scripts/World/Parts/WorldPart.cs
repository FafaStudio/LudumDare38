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

	int baseOxygenProduct;
	int baseWoodProduct;
	int baseMineralProduct;
	int baseEnergieProduct;
	int baseGemProduct;

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

    public void setOxygenProduct(int product){baseOxygenProduct = product;}
	public void setWoodProduct(int product){baseWoodProduct = product;}
	public void setMineralProduct(int product){baseMineralProduct = product;}
	public void setEnergieProduct(int product){baseEnergieProduct = product;}
	public void setGemProduct(int product){baseGemProduct = product;}

	public int getOxygenProduct(){
		return baseOxygenProduct * mainConstruct.getOxygenMultiplicatorProduction() + mainConstruct.getOxygenProduction() - secondaryConstruct.getOxygenCost();
	}
	public int getWoodProduct(){
		return baseWoodProduct * mainConstruct.getWoodMultiplicatorProduction() + mainConstruct.getWoodProduction();
	}
	public int getMineralProduct(){
		return baseMineralProduct * mainConstruct.getMineralMultiplicatorProduction() + mainConstruct.getMineralProduction();
	}
	public int getEnergieProduct(){
		return baseEnergieProduct * mainConstruct.getEnergieMultiplicatorProduction() + mainConstruct.getEnergieProduction() - mainConstruct.getEnergyCost() - secondaryConstruct.getEnergyCost();
	}
	public int getGemProduct(){
		return baseGemProduct * mainConstruct.getGemMultiplicatorProduction() + mainConstruct.getGemProduction() ;
	}


	public void setIsSterile(bool boolean){isSterile = boolean;}

	public bool getIsSterile(){
		return isSterile;
	}
}
