using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenSeed : Consumable {
	public override void useItem(WorldPart partLinked){
		partLinked.setIsSterile(false);
	}

	public override bool canBeUse(WorldPart partLinked){
		return partLinked.getIsSterile();
	}
}
