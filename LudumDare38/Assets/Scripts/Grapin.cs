﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapin : MonoBehaviour {

	Vector3 destination;
	MovementController player;

	float distanceFromPlayer;
	public float distanceMaxFromPlayer;

	public GameObject shadow;
	public GameObject poulpiSprite;

	bool isLaunch=false;
	bool comeBack=false;

	bool isRight = true;

	bool sens;

	void Update () {
		detectSensPlayer ();
		if (!isLaunch) {
			shadow.SetActive (true);
			calculateDistanceFromPlayer ();
			if (distanceFromPlayer > distanceMaxFromPlayer) {
				movePoulpi ();
			}
			return;
		}
		shadow.SetActive (false);
		if(comeBack)
			destination = player.transform.position;
		transform.position = Vector3.MoveTowards(transform.position, destination, 5f*Time.deltaTime);
		if (this.transform.position == destination) {
			if (comeBack) {
				comeBack = false;
				player.endGrab ();
			} 
			else {
				destination = player.transform.position;
				comeBack = true;
			}
		}
	}

	void movePoulpi(){
		detectSensPlayer ();
		if(sens){
			poulpiSprite.GetComponent<SpriteRenderer> ().flipX = true;
			transform.RotateAround (new Vector3 (0f, 0f, 0f), new Vector3 (0f, 0f, 1f), 0.7f);
		}	else	{
			poulpiSprite.GetComponent<SpriteRenderer> ().flipX = false;
			transform.RotateAround (new Vector3 (0f, 0f, 0f), new Vector3 (0f, 0f, 1f), -0.7f);
		}
	}

	public void flipSprite(){
		if(sens){
			poulpiSprite.GetComponent<SpriteRenderer> ().flipX = true;
		}	else	{
			poulpiSprite.GetComponent<SpriteRenderer> ().flipX = false;
		}
	}

	public void detectSensPlayer(){
	//le player est a droite ou a gauche 
		sens = player.transform.rotation.eulerAngles.z > transform.rotation.eulerAngles.z;
		if(Mathf.Abs(player.transform.rotation.eulerAngles.z - transform.rotation.eulerAngles.z) > 180){
			sens = !sens;
		}
		flipSprite ();
	}

	public void calculateDistanceFromPlayer(){
		distanceFromPlayer = Mathf.Sqrt (Mathf.Pow(transform.position.x - player.transform.position.x,2)+Mathf.Pow(transform.position.y - player.transform.position.y,2));
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
			destination = player.transform.position;
			comeBack = true;
		}

		if (other.gameObject.tag == "Player") {
			if (isLaunch)
				return;
			isRight = !isRight;
		}
	}
}
