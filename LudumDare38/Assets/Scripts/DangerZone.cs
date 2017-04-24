using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag =="Menace") {
			MusicManager.instance.launchBatuluPiste ();
		}
	}
}
