﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceVolante : MonoBehaviour {

	Vector3 direction;
	bool canMove=true;

	enum ressource{oxygen, wood, mineral, energy, gem};
	ressource currentRessource;

	public SpriteRenderer caps;

	public Sprite oxygenSprite;
	public Sprite woodSprite;
	public Sprite mineralSprite;
	public Sprite energySprite;
	public Sprite gemSprite;

	private bool magnetized;

	GameObject magnet;

	void Start () {
		currentRessource = GetRandomEnum<ressource> ();
		direction = new Vector3 (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), 0f);
		setCapsSprite ();
		Destroy (this.gameObject, 45f);
	}

	static T GetRandomEnum<T>(){
		System.Array A = System.Enum.GetValues(typeof(T));
		T V = (T)A.GetValue(UnityEngine.Random.Range(0,A.Length));
		return V;
	}

	void Update () {
		if(magnetized){
			transform.position = Vector3.MoveTowards(transform.position, magnet.transform.position, 4f*Time.deltaTime);
			if(transform.position == magnet.transform.position){
				gainRessource();
			}
		}

		if(canMove)
			transform.Translate (direction);
	}

	void setCapsSprite(){
		switch (currentRessource) {
		case ressource.energy:
			caps.sprite = energySprite;
			break;
		case ressource.gem:
			caps.sprite = gemSprite;
			break;
		case ressource.mineral:
			caps.sprite = mineralSprite;
			break;
		case ressource.oxygen:
			caps.sprite = oxygenSprite;
			break;
		case ressource.wood:
			caps.sprite = woodSprite;
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

		if(other.gameObject.tag == "Magnet"){
			if(!magnet){
				magnet = other.gameObject;
				magnetized = true;
				canMove = false;
			}
			
			//direction = (other.transform.position - this.transform.position).normalized;
		}
	}

	public void gainRessource(){
		TutorialController.instance.nextIfPosition(4);
		SoundManager.instance.launchSound ("getRessource");
		switch (currentRessource) {
		case ressource.energy:
			GameManager.instance.addEnergy (50f);
			break;
		case ressource.gem:
			GameManager.instance.addGem (10f);
			break;
		case ressource.mineral:
			GameManager.instance.addMineral (50f);
			break;
		case ressource.oxygen:
			GameManager.instance.addOxygen (50f);
			break;
		case ressource.wood:
			GameManager.instance.addWood (50f);
			break;
		}
		Destroy (this.gameObject);
	}
}
