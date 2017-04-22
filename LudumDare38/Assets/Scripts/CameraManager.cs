using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	Camera camera;
	public Transform mainCharacter;

	void Awake () {
		camera = GetComponent<Camera> ();
	}

	void Update () {
	//positif : je dezoom
	//negatif : je zoom
		camera.orthographicSize += Input.GetAxis ("Mouse ScrollWheel")*0.5f;
		if (camera.orthographicSize > 7)
			camera.orthographicSize = 7;
		else if (camera.orthographicSize < 4) {
			//lerp sur le perso
			if (transform.position != mainCharacter.position) {
				transform.position = Vector3.MoveTowards(transform.position, new Vector3 (mainCharacter.position.x, mainCharacter.position.y, -10f), 10f*Time.deltaTime);
			}
		}else if(camera.orthographicSize > 4) {
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f,0f,-10f), 10f*Time.deltaTime);
		}
		if (camera.orthographicSize < 1.5f)
			camera.orthographicSize = 1.5f;
	}
}
