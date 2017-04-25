using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alienicide : Consumable {
	public override void useItem(WorldPart partLinked){
		SpaceSpawner.instance.actualAlien.GetComponent<AlienScript>().worldPart.GetComponent<WorldPart>().unalienize();
	}

	public override bool canBeUse(WorldPart partLinked){
		if(SpaceSpawner.instance.actualAlien != null){
			return SpaceSpawner.instance.actualAlien.GetComponent<AlienScript>().worldPart.GetComponent<WorldPart>().getIsAliened();
		}	else	{
			return false;
		}
	}

	
}
