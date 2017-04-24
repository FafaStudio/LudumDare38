using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDetector : MonoBehaviour {
	WorldPart worldPart;
	void Awake(){
		worldPart = transform.parent.gameObject.GetComponent<WorldPart>();
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.GetComponent<AlienScript>() != null){
			if(worldPart.isAlienProtected()){
				coll.gameObject.GetComponent<AlienScript>().runAway();
			}
		}	else	if(coll.gameObject.GetComponent<Asteroid>() != null){
			if(worldPart.isAsteroideProtected()){
				coll.gameObject.GetComponent<Asteroid>().runAway();
			}
		}
			
	}
}
