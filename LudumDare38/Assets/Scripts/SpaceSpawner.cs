using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSpawner : MonoBehaviour {

	public GameObject ressourceVolante;

	public GameObject asteroid;

	float maxTimeBetweenRessource;
	float timePassed;

	void Start () {
		maxTimeBetweenRessource = Random.Range (1f, 5f);
		timePassed = maxTimeBetweenRessource;
	}

	void Update () {
		timePassed -= Time.deltaTime;
		if (timePassed <= 0) {
			InstantiateRessource ();
			maxTimeBetweenRessource = Random.Range (1f, 5f);
			timePassed = maxTimeBetweenRessource;
		}
	}

	public void InstantiateRessource(){
		GameObject toInstantiate;
		int testProba = (int)Random.Range (0f, 100f);
		if (testProba > 30) 
			toInstantiate = Instantiate (ressourceVolante, this.transform.position, Quaternion.identity) as GameObject;
		else
			toInstantiate = Instantiate (asteroid, this.transform.position, Quaternion.identity) as GameObject;
		toInstantiate.transform.parent = this.transform;
	}
}
