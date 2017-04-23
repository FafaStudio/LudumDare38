using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPart : WorldPart {
	
	// Use this for initialization
	void Start () {
		setOxygenMultiplicator(2);
		setWoodMultiplicator(2);
		setMineralMultiplicator(0.75f);
		setEnergieMultiplicator(1);
		setGemMultiplicator(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public override void dismissSterile(){
		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HERBE");
	}
}
