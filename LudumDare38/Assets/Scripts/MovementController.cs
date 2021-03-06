﻿	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
	
	Rigidbody2D body;
	public Builder builder;

	Camera camera;

	bool canMove=true;

	public Grapin grapin;
	bool grabbing=false;

	Animator anim;
	SpriteRenderer sprite;

	bool isBlock;
	bool previousOrientation;

	void Awake() {
		body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sprite = GetComponent<SpriteRenderer> ();
		camera = Camera.main;
	}

	void Start(){
		grapin.setPlayer (this);
		//grapin.gameObject.SetActive (false);
	}

	void Update(){
		if (Input.GetMouseButtonDown (1)&&(!grabbing)) {
			//click droit
			//grapin.transform.position = this.transform.position;
			useGrab(camera.ScreenToWorldPoint (Input.mousePosition));
		} 
	}

	void FixedUpdate () {
		//if (!canMove)
		//	return;
		if ((Input.GetKey (KeyCode.A)||(Input.GetKey (KeyCode.Q)))) {
			TutorialController.instance.nextIfPosition(2);
			if(previousOrientation && isBlock){
				return;
			}
			anim.SetBool ("isWalking", true);
			sprite.flipX = true;
			transform.RotateAround (new Vector3 (0f, 0f, 0f), new Vector3 (0f, 0f, 1f), 1f);
		} else if (Input.GetKey (KeyCode.D)) {
			TutorialController.instance.nextIfPosition(2);
			if(!previousOrientation && isBlock){
				return;
			}
			sprite.flipX = false;
			anim.SetBool ("isWalking", true);
			transform.RotateAround (new Vector3 (0f, 0f, 0f), new Vector3 (0f, 0f, 1f), -1f);
		} else {
			anim.SetBool ("isWalking", false);
		}
	}

	void useGrab(Vector3 finalPosition){
		canMove=false;
		grabbing = true;
		finalPosition.z = 0f;
		//grapin.gameObject.SetActive (true);
		grapin.setDestination (finalPosition);
		grapin.setIsLaunch (true);//lance le grapin
	}

	public void endGrab(){
		grabbing = false;
		canMove = true;
		grapin.setIsLaunch (false);
		grapin.transform.rotation = this.transform.rotation;
		//grapin.gameObject.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.tag=="Ground")
			builder.setActualPart(coll.gameObject);
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Menace") {
			previousOrientation = sprite.flipX;
			isBlock = true;
		}
	}
	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "Menace") {
			isBlock = false;
		}
	}


}
