using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapin : MonoBehaviour {

	Vector3 destination;
	MovementController player;

	bool isLaunch=false;
	bool triggerOff=false;

	void Update () {
		if (!isLaunch)
			return;
		transform.position = Vector3.MoveTowards(transform.position, destination, 10f*Time.deltaTime);
		if (this.transform.position == destination) {
			destination = player.transform.position;
		}
	}

	public void setDestination(Vector3 val){
		destination = val;
	}

	public void setTriggerOff(bool val){
		triggerOff = val;
	}

	public void setPlayer(MovementController val){
		player = val;
	}

	public void setIsLaunch(bool val){
		isLaunch = val;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		
		if (coll.gameObject.tag == "Player"){
			if (!triggerOff) {
				player.endGrab ();
			}
		}
	}
}
