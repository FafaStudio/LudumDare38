using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour {
	GameObject worldPart;
	// Use this for initialization
	void Start () {
		findWorldPart();
		transform.rotation = Quaternion.Euler(0, 0, worldPart.transform.rotation.eulerAngles.z-75);
	}
	
	// Update is called once per frame
	void Update () {
		goToWorldPart();
	}
	private void findWorldPart(){
		worldPart = Physics2D.Raycast(transform.position, (new Vector3(0,0) - this.transform.position).normalized, Mathf.Infinity, 1 << 8).collider.gameObject;
	}

	private void goToWorldPart(){
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(worldPart.transform.position.x + 3.4f, worldPart.transform.position.y), 8f*Time.deltaTime);
	}

	

}
