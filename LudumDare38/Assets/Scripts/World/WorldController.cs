using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {


	List<WorldPart> worldParts;
	public GrassPart grassPart;
	public MineralPart mineralPart;
	public GemPart gemPart;
	// Use this for initialization
	void Awake () {
		setWorldParts();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void setWorldParts(){
		worldParts = new List<WorldPart>();
		float partNumber = 16;
		int miniGrassNumber = 3;
		int miniMineralNumber = 3;
		float grassNumber = 7;
		float mineralNumber = 7;
		float gemNumber = 2;
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
			float partRandomValue = Random.value;
			if((mineralNumber == 0 && gemNumber == 0) || (partRandomValue < grassNumber/(partNumber - i) && grassNumber != 0)){
				worldParts.Add(instantiateWorldPart(i, grassPart));
				//on add un grass
				grassNumber--;
			}	else	if(gemNumber == 0 || (partRandomValue < grassNumber + mineralNumber/(partNumber - i) && mineralNumber != 0)){
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
			int sterileRandomValue = Random.Range(6,15);//mettre en stérile parfois
			if(!worldParts[sterileRandomValue].getIsSterile()){
				worldParts[sterileRandomValue].setIsSterile(true);
				sterileNumber--;
			}
		}
	}

	private WorldPart instantiateWorldPart(int index, WorldPart worldPart){
		WorldPart instance = Instantiate(worldPart, transform.position, Quaternion.Euler(0, 0, (float)-22.5*index), transform);
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
