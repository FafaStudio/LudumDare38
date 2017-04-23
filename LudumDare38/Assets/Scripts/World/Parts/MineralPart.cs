using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralPart : WorldPart {

	// Use this for initialization
	void Start () {
		setMultiplicator();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void dismissSterile(){
		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("MINERAL");
		setMultiplicator();
	}
	public override void setMultiplicator(){
		setOxygenMultiplicator(0.5f);
		setWoodMultiplicator(1);
		setMineralMultiplicator(2);
		setEnergieMultiplicator(2);
		setGemMultiplicator(0.5f);
	}
}
