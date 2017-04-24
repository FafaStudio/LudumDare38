using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienGenerator : MonoBehaviour {
	public GameObject alien;
	// Use this for initialization
	void Start () {
		InstantiateAlien();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	Vector3 getRandomOuterPosition(){
		int xValue = 0;
		int yValue = 0;
		while(xValue < 15 && xValue > -15 && yValue < 15 && yValue > -15){
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
