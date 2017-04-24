using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceVolante : MonoBehaviour {

	Vector3 direction;
	bool canMove=true;

	enum ressource{oxygen, wood, mineral, energy, gem};
	ressource currentRessource;

	public SpriteRenderer caps;

	public Color oxygenColor;
	public Color woodColor;
	public Color mineralColor;
	public Color energyColor;
	public Color gemColor;

	void Start () {
		currentRessource = GetRandomEnum<ressource> ();
		direction = new Vector3 (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), 0f);
		setCapsColor ();
		Destroy (this.gameObject, 45f);
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

	void setCapsColor(){
		switch (currentRessource) {
		case ressource.energy:
			caps.color = energyColor;
			break;
		case ressource.gem:
			caps.color = gemColor;
			break;
		case ressource.mineral:
			caps.color = mineralColor;
			break;
		case ressource.oxygen:
			caps.color = oxygenColor;
			break;
		case ressource.wood:
			caps.color = woodColor;
			break;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag =="Ground") {
			this.transform.parent = other.gameObject.transform;
			canMove = false;
		}
		if (other.gameObject.tag =="Menace") {
			Destroy (this.gameObject);
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
