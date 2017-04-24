using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoPlug : Consumable {
	public override void useItem(WorldPart partLinked){
	}

	public override bool canBeUse(WorldPart partLinked){
		return true;
	}
}
