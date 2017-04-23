using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapin : MonoBehaviour {

	Vector3 destination;
	MovementController player;

	bool isLaunch=false;
	bool comeBack=false;

	void Update () {
		if (!isLaunch)
			return;
		transform.position = Vector3.MoveTowards(transform.position, destination, 5f*Time.deltaTime);
		if (this.transform.position == destination) {
			if (comeBack) {
				player.endGrab ();
				comeBack = false;
			} else {
				destination = player.transform.position;
				comeBack = true;
			}
		}
	}

	public void setDestination(Vector3 val){
		destination = val;
	}

	public void setPlayer(MovementController val){
		player = val;
	}

	public void setIsLaunch(bool val){
		isLaunch = val;
	}
		

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag =="Ground") {
			print ("wow");
		}
	}
}
