using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPart : MonoBehaviour {
	int index;
	
	public MainConstruct mainConstruct;
	public SecondaryConstruct secondaryConstruct;

	bool isSterile;
	bool isOccuped;

	int baseOxygenProduct;
	int baseWoodProduct;
	int baseMineralProduct;
	int baseEnergieProduct;
	int baseGemProduct;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addMainConstruct(MainConstruct mainConstruct){

	}

	public void removeMainConstruct(){
		
	}

	public void addSecondaryConstruct(SecondaryConstruct secondaryConstruct){

	}

	public void removeSecondaryConstruct(){
		
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
