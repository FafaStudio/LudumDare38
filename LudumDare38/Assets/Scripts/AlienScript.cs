using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour {
	public GameObject worldPart;

	Vector3 origin;
	Vector3 objective;

	float chronoSound = 0f;
	float maxChronoSound = 0f;

	bool alienised = false;
	bool isRunningAway = false;

	void Start () {
		MusicManager.instance.launchBatuluPiste ();
		GameManager.instance.addMenace (this.gameObject);

		origin = transform.position;
		findWorldPart();
		transform.rotation = Quaternion.Euler(0, 0, worldPart.transform.rotation.eulerAngles.z-75);
		objective = worldPart.GetComponent<WorldPart>().anchor.transform.position;
	}

	void Update () {
		if (transform.position != objective) {
			goToWorldPart ();
		} else {
			playSound ();
			if (!alienised) {
				alienised = true;
				worldPart.GetComponent<WorldPart> ().alienize (gameObject);
			}
		}
	}
	private void findWorldPart(){
		worldPart = Physics2D.Raycast(transform.position, (new Vector3(0,0) - this.transform.position).normalized, Mathf.Infinity, 1 << 8).collider.gameObject;
	}

	private void goToWorldPart(){
		transform.position = Vector3.MoveTowards(transform.position, objective, 8f*Time.deltaTime);
	}

	public void playSound(){
		if (isRunningAway)
			return;
		chronoSound -= Time.deltaTime;
		if (chronoSound <= 0f) {
			SoundManager.instance.launchSound ("menaceGuepe");
			maxChronoSound = 8f;
			chronoSound = maxChronoSound;
		}
	}

	public void runAway(){
		isRunningAway = true;
		SoundManager.instance.launchSound ("guepeRepulsed");
		objective = origin;
		SpaceSpawner.instance.setHasSpawnedalien (false);
		GameManager.instance.removeMenace (this.gameObject);
		SpaceSpawner.instance.actualAlien = null;
		Destroy(gameObject, 5);
	}


}
