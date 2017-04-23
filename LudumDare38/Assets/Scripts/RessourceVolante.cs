using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceVolante : MonoBehaviour {

	Vector3 direction;
	bool canMove=true;

	enum ressource{oxygen, wood, mineral, energy, gem};
	ressource currentRessource;

	void Start () {
		currentRessource = GetRandomEnum<ressource> ();
		direction = new Vector3 (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), 0f);
		Destroy (this.gameObject, 30f);
	}

	static T GetRandomEnum<T>(){
		System.Array A = System.Enum.GetValues(typeof(T));
		T V = (T)A.GetValue(UnityEngine.Random.Range(0,A.Length));
		return V;
	}

	void Update () {
		if(canMove)
			transform.Translate (direction);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag =="Ground") {
			canMove = false;
		}

		if (other.gameObject.tag == "Grapin") {
			canMove = false;
		}

		if (other.gameObject.tag == "Player") {
			gainRessource ();
		}
	}

	public void gainRessource(){
		switch (currentRessource) {
		case ressource.energy:
			GameManager.instance.addEnergy (100f);
			break;
		case ressource.gem:
			GameManager.instance.addGem (100f);
			break;
		case ressource.mineral:
			GameManager.instance.addMineral (100f);
			break;
		case ressource.oxygen:
			GameManager.instance.addOxygen (100f);
			break;
		case ressource.wood:
			GameManager.instance.addWood (100f);
			break;
		}
		Destroy (this.gameObject);
	}
}
