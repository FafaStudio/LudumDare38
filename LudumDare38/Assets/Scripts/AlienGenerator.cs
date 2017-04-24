using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienGenerator : MonoBehaviour {
	public GameObject alien;

	void Start () {
		InstantiateAlien();
	}

	Vector3 getRandomOuterPosition(){
		int xValue = 0;
		int yValue = 0;
<<<<<<< HEAD
		while(xValue < 15 && xValue > -15 && yValue < 15 && yValue > 15){
=======
		while(xValue < 15 && xValue > -15 && yValue < 15 && yValue > -15){
>>>>>>> eb0a9385b17608d568878673035c9b909b828140
			xValue = Random.Range(-30,30);
			yValue = Random.Range(-30,30);
		}
		return new Vector3(xValue, yValue);
	}

	
	public void InstantiateAlien(){
		GameObject toInstantiate = Instantiate (alien, getRandomOuterPosition(), Quaternion.identity) as GameObject;
		//toInstantiate.transform.parent = this.transform;
	}
}
