using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyspaceFX : MonoBehaviour {

	public Sprite[] skyspace;
	SpriteRenderer sprite;

	void Awake () {
		sprite = GetComponent<SpriteRenderer> ();
		setBackgroundSpace ();
	}

	void setBackgroundSpace(){
		sprite.sprite = skyspace [(int)Random.Range (0f, skyspace.Length)];
	}
}
