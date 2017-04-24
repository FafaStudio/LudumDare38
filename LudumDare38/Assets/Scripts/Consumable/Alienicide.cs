using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alienicide : Consumable {
	public override void useItem(WorldPart partLinked){
		partLinked.unalienize();
	}

	public override bool canBeUse(WorldPart partLinked){
		return partLinked.getIsAliened();
	}

	
}
