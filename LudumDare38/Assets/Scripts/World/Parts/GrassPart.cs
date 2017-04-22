using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPart : WorldPart {
	
	// Use this for initialization
	void Start () {
		setOxygenMultiplicator(10);
		setWoodMultiplicator(10);
		setMineralMultiplicator(0);
		setEnergieMultiplicator(0);
		setGemMultiplicator(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
