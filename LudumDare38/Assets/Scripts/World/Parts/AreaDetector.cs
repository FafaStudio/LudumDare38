using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDetector : MonoBehaviour {
	WorldPart worldPart;

	public GameObject actualAlien;
	public GameObject actualAsteroid;
	void Awake(){
		worldPart = transform.parent.gameObject.GetComponent<WorldPart>();
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.GetComponent<AlienScript>() != null){
			actualAlien = coll.gameObject;
			if(worldPart.isAlienProtected()){
				coll.gameObject.GetComponent<AlienScript>().runAway();
				if(worldPart.secondaryConstruct.GetComponent<alienCounterSecondary>() != null){
					worldPart.secondaryConstruct.useDurability();
				}
			}
		}	else	if(coll.gameObject.GetComponent<Asteroid>() != null){
			actualAsteroid = coll.gameObject;
			if(worldPart.isAsteroideProtected()){
				coll.gameObject.GetComponent<Asteroid>().runAway();
				if(worldPart.secondaryConstruct.GetComponent<AsteroideCounterSecondary>() != null){
					worldPart.secondaryConstruct.useDurability();
				}
			}
		}	
	}
}
