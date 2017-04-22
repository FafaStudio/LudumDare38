using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPart : WorldPart {

	// Use this for initialization
	void Start () {
		setOxygenMultiplicator(0);
		setWoodMultiplicator(0);
		setMineralMultiplicator(0);
		setEnergieMultiplicator(0);
		setGemMultiplicator(10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
