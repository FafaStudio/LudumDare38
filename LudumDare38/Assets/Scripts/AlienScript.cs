﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour {
	public GameObject worldPart;

	Vector3 origin;
	Vector3 objective;

	float chronoSound = 0f;
	float maxChronoSound = 0f;

	void Start () {
		MusicManager.instance.launchBatuluPiste ();
		GameManager.instance.addMenace (this.gameObject);

		origin = transform.position;
		findWorldPart();
		transform.rotation = Quaternion.Euler(0, 0, worldPart.transform.rotation.eulerAngles.z-75);
		worldPart.GetComponent<WorldPart>().alienize(gameObject);
		objective = worldPart.GetComponent<WorldPart>().anchor.transform.position;
	}

	void Update () {
		if (transform.position != objective) {
			goToWorldPart ();
		} else {
			playSound ();
		}
	}
	private void findWorldPart(){
		worldPart = Physics2D.Raycast(transform.position, (new Vector3(0,0) - this.transform.position).normalized, Mathf.Infinity, 1 << 8).collider.gameObject;
	}

	private void goToWorldPart(){
		transform.position = Vector3.MoveTowards(transform.position, objective, 8f*Time.deltaTime);
	}

	public void playSound(){
		chronoSound -= Time.deltaTime;
		if (chronoSound <= 0f) {
			SoundManager.instance.launchSound ("menaceGuepe");
			maxChronoSound = 8f;
			chronoSound = maxChronoSound;
		}
	}

	public void runAway(){
		objective = origin;
		SpaceSpawner.instance.setHasSpawnedalien (false);
<<<<<<< HEAD
		GameManager.instance.removeMenace (this.gameObject);
=======
		SpaceSpawner.instance.actualAlien = null;
>>>>>>> d2e0699a71929f8614f0149d30022d3fd0c2197c
		Destroy(gameObject, 5);
	}


}
