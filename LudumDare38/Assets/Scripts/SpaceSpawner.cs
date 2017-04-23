using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSpawner : MonoBehaviour {

	public GameObject ressourceVolante;

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
		GameObject toInstantiate = Instantiate (ressourceVolante, this.transform.position, Quaternion.identity) as GameObject;
		toInstantiate.transform.parent = this.transform;
	}
}
