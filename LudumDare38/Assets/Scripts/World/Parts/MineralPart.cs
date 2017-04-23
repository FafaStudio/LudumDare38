using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralPart : WorldPart {

	// Use this for initialization
	void Start () {
		setOxygenMultiplicator(0);
		setWoodMultiplicator(0);
		setMineralMultiplicator(10);
		setEnergieMultiplicator(10);
		setGemMultiplicator(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void dismissSterile(){
		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("MINERAL");
	}
}
