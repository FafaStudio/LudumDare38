using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour {
	GameObject worldPart;

	Vector3 origin;
	Vector3 objective;
	// Use this for initialization
	void Start () {
		origin = transform.position;
		findWorldPart();
		transform.rotation = Quaternion.Euler(0, 0, worldPart.transform.rotation.eulerAngles.z-75);
		worldPart.GetComponent<WorldPart>().alienize(gameObject);
		objective = worldPart.GetComponent<WorldPart>().anchor.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position != objective){
			goToWorldPart();
		}
	}
	private void findWorldPart(){
		worldPart = Physics2D.Raycast(transform.position, (new Vector3(0,0) - this.transform.position).normalized, Mathf.Infinity, 1 << 8).collider.gameObject;
	}

	private void goToWorldPart(){
		transform.position = Vector3.MoveTowards(transform.position, objective, 8f*Time.deltaTime);
	}

	public void runAway(){
		objective = origin;
		Destroy(gameObject, 5);
	}


}
