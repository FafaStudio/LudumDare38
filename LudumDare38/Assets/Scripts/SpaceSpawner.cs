﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSpawner : MonoBehaviour {

	public bool spawnAlien;
	public bool spawnAsteroid;
	public bool spawnEruption;

	public GameObject ressourceVolante;

	public GameObject asteroid;
	public GameObject alien;

	public GameObject actualAlien;

	bool spawnedAlien = false;

	float maxTimeBetweenRessource;
	float timerRessource;

	float timerMenace;

	bool start=false;

	void Start () {
		maxTimeBetweenRessource = Random.Range (1f, 5f);
		timerRessource = maxTimeBetweenRessource;
		timerMenace = Random.Range (30f, 120f);
	}

	Vector3 getRandomOuterPosition(){
		int xValue = 0;
		int yValue = 0;
		while(xValue < 15 && xValue > -15 && yValue < 15 && yValue > -15){
			xValue = Random.Range(-18,18);
			yValue = Random.Range(-18,18);
		}
		return new Vector3(xValue, yValue);
	}

	void Update () {
		timerRessource -= Time.deltaTime;
		if (timerRessource <= 0) {
			InstantiateObject (ressourceVolante);
			maxTimeBetweenRessource = Random.Range (0.2f, 1f);
			timerRessource = maxTimeBetweenRessource;
		}

		if (spawnAlien) {
			spawnAlien = false;
			spawnMenace ("Alien");
		}

		if (spawnAsteroid) {
			spawnAsteroid = false;
			spawnMenace ("Asteroid");
		}
		if (spawnEruption) {
			spawnEruption = false;
			spawnMenace ("Eruption");
		}

		if (!start)
			return;
		timerMenace -= Time.deltaTime;
		if (timerMenace <= 0) {
			int rand = (int)Random.Range (0f, 2f);
			if (rand == 0) {
				spawnMenace ("Alien");
				setTimerMenace ();
			} else {
				spawnMenace ("Asteroid");
				setTimerMenace ();
			}
		}
	}

	public void setTimerMenace(){
		if(GameManager.instance.getDay()>3)
			timerMenace = Random.Range (30f/GameManager.instance.getDay()-3, 120f/(GameManager.instance.getDay()-3));
		else
			timerMenace = Random.Range (30f/GameManager.instance.getDay(), 120f/(GameManager.instance.getDay()));
	}

	public void spawnMenace(string menace){
		if (menace == "Alien") {
			if (spawnedAlien)
				return;
			spawnedAlien = true;
			actualAlien = InstantiateObject (alien);
		} else if (menace == "Asteroid") {
			InstantiateObject (asteroid);
		} else if (menace == "Eruption") {
			WorldController.instance.launchPartEruption (0);
		}
	}

	public void trySpawnEruption(){
		int random = (int)Random.Range (0f, 10f);
		if (random == 0) {
			spawnMenace ("Eruption");
			spawnMenace ("Eruption");
			spawnMenace ("Eruption");
			spawnMenace ("Eruption");
		}
		if (random < 3) {
			spawnMenace ("Eruption");
			spawnMenace ("Eruption");
			spawnMenace ("Eruption");
		}else if (random < 5) {
			spawnMenace ("Eruption");
			spawnMenace ("Eruption");
		}else if(random <8){
			spawnMenace ("Eruption");
		}else
			spawnMenace ("Eruption");
	}

	public void startMenace(){
		start = true;
	}

	public void stopMenace(){
		start = false;
	}

	public GameObject InstantiateObject(GameObject objectToInstantiate ){
		GameObject toInstantiate;
		toInstantiate = Instantiate (objectToInstantiate, getRandomOuterPosition(), Quaternion.identity) as GameObject;
		toInstantiate.transform.parent = this.transform;
		return toInstantiate;
	}

	public void setHasSpawnedalien(bool val){
		spawnedAlien = val;
	}

	private static SpaceSpawner s_Instance = null;

	// This defines a static instance property that attempts to find the manager object in the scene and
	// returns it to the caller.
	public static SpaceSpawner instance
	{
		get
		{
			if (s_Instance == null)
			{
				// This is where the magic happens.
				//  FindObjectOfType(...) returns the first AManager object in the scene.
				s_Instance = FindObjectOfType(typeof(SpaceSpawner)) as SpaceSpawner;
			}

			// If it is still null, create a new instance
			if (s_Instance == null)
			{
				GameObject obj = Instantiate(Resources.Load("SpaceSpawner") as GameObject);
				s_Instance = obj.GetComponent<SpaceSpawner>();
			}
			return s_Instance;
		}
	}
}
