using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
	
	Rigidbody2D body;
	public Builder builder;

	Camera camera;

	bool canMove=true;

	public Grapin grapin;
	bool grabbing=false;

	void Awake() {
		body = GetComponent<Rigidbody2D> ();
		camera = Camera.main;
	}

	void Start(){
		grapin.setPlayer (this);
		grapin.gameObject.SetActive (false);
	}

	void Update(){
		if (Input.GetMouseButtonDown (1)&&(!grabbing)) {
			//click droit
			grapin.transform.position = this.transform.position;
			useGrab(camera.ScreenToWorldPoint (Input.mousePosition));
		} 
	}

	void FixedUpdate () {
		if (!canMove)
			return;
		if(Input.GetKey(KeyCode.Q))
			transform.RotateAround (new Vector3(0f,0f,0f), new Vector3(0f,0f,1f),1f);
		else if(Input.GetKey(KeyCode.D))
			transform.RotateAround (new Vector3(0f,0f,0f), new Vector3(0f,0f,1f),-1f);
	}

	void useGrab(Vector3 finalPosition){
		canMove=false;
		grabbing = true;
		finalPosition.z = 0f;
		grapin.gameObject.SetActive (true);
		grapin.setDestination (finalPosition);
		StartCoroutine (tempoGrab ());
		grapin.setIsLaunch (true);//lance le grapin
	}

	IEnumerator tempoGrab(){
		// pour empecher le trigger lorsque je lance poulpi
		grapin.setTriggerOff (true);
		yield return new WaitForSeconds(0.05f);
		grapin.setTriggerOff (false);
	}

	public void endGrab(){
		grabbing = false;
		canMove = true;
		grapin.setIsLaunch (false);
		grapin.gameObject.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.tag=="Ground")
			builder.setActualPart(coll.gameObject);
	}
}
