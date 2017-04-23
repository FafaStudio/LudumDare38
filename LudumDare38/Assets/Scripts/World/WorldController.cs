﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {


	List<WorldPart> worldParts;
	public GrassPart grassPart;
	public MineralPart mineralPart;
	public GemPart gemPart;

	void Awake () {
		setWorldParts();
	}
		
	void Update () {
		
	}

	private void setWorldParts(){
		worldParts = new List<WorldPart>();
		float partNumber = 24;
		int miniGrassNumber = 3;
		int miniMineralNumber = 3;
		float gemNumber = Random.Range(2,5);
		float grassNumber = Random.Range(4,17);
		float mineralNumber =partNumber - gemNumber - grassNumber;
		int sterileNumber = 4;

		for (int i = 0; i < 6; i++)//on assure un spawn decent
		{
			if(miniMineralNumber == 0 || (Random.value < 0.5 && miniGrassNumber != 0)){
				worldParts.Add(instantiateWorldPart(i, grassPart));
				//on add un grass
				grassNumber--;
				miniGrassNumber--;
			}	else	{
				worldParts.Add(instantiateWorldPart(i, mineralPart));
				//on add un mineral
				mineralNumber--;
				miniMineralNumber--;
			}
		}

		for (int i = 6; i < partNumber; i++)
		{
			int partRandomValue;
			if(grassNumber == 0){
				partRandomValue = Random.Range(1,3);
			}	else	if(mineralNumber == 0 || gemNumber == 0){
				partRandomValue = Random.Range(0,2);
			}	else	{
				partRandomValue = Random.Range(0,3);
			}

			if((mineralNumber == 0 && gemNumber == 0) || (partRandomValue == 0 && grassNumber != 0)){
				worldParts.Add(instantiateWorldPart(i, grassPart));
				//on add un grass
				grassNumber--;
			}	else if(gemNumber == 0 || (partRandomValue == 1 && mineralNumber != 0)){
				worldParts.Add(instantiateWorldPart(i, mineralPart));
				//on add un mineral
				mineralNumber--;
			}	else	{
				worldParts.Add(instantiateWorldPart(i, gemPart));
				//on add un gem
				gemNumber--;
			}
		}

		while(sterileNumber > 0){
			int sterileRandomValue = Random.Range(6,23);//mettre en stérile parfois
			if(!worldParts[sterileRandomValue].getIsSterile()){
				worldParts[sterileRandomValue].setIsSterile(true);
				sterileNumber--;
			}
		}
	}

	private WorldPart instantiateWorldPart(int index, WorldPart worldPart){
		WorldPart instance = Instantiate(worldPart, transform.position, Quaternion.Euler(0, 0, (float)-15*index), transform);
		instance.name = "Part " + index + " (" + instance.GetType() + ")"; 
		return instance;
	}

	public int getDayOxygenProduct(){
		int product = 0;
		for (int i = 0; i < worldParts.Count; i++)
		{
			product = worldParts[i].getOxygenProduct();
		}
		return product;
	}
	public int getDayWoodProduct(){
		int product = 0;
		for (int i = 0; i < worldParts.Count; i++)
		{
			product = worldParts[i].getWoodProduct();
		}
		return product;
	}
	public int getDayMineralProduct(){
		int product = 0;
		for (int i = 0; i < worldParts.Count; i++)
		{
			product = worldParts[i].getMineralProduct();
		}
		return product;
	}
	public int getDayEnergieProduct(){
		int product = 0;
		for (int i = 0; i < worldParts.Count; i++)
		{
			product = worldParts[i].getEnergieProduct();
		}
		return product;
	}
	public int getDayGemProduct(){
		int product = 0;
		for (int i = 0; i < worldParts.Count; i++)
		{
			product = worldParts[i].getGemProduct();
		}
		return product;
	}
}
