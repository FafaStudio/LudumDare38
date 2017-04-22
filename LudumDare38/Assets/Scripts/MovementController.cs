using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	Rigidbody2D body;

	void Awake() {
		body = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		if(Input.GetKey(KeyCode.Q))
			transform.RotateAround (new Vector3(0f,0f,0f), new Vector3(0f,0f,1f),1f);
		else if(Input.GetKey(KeyCode.D))
			transform.RotateAround (new Vector3(0f,0f,0f), new Vector3(0f,0f,1f),-1f);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		print (coll.gameObject);
	}
}
