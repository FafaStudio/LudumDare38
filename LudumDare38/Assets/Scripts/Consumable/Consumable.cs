using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour {
	public virtual void useItem(WorldPart partLinked){}
	public virtual bool canBeUse(WorldPart partLinked){return true;}

}
