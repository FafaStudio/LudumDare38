using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPart : WorldPart {

	// Use this for initialization
	void Start () {
		setMultiplicator();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	public override void dismissSterile(){
		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("GEMME");
		setMultiplicator();
	}

	public override void setMultiplicator(){
		setOxygenMultiplicator(1);
		setWoodMultiplicator(0.5f);
		setMineralMultiplicator(0.75f);
		setEnergieMultiplicator(1.5f);
		setGemMultiplicator(2);
	}
}
