using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	Vector3 direction;

	float speedRotation;

	public Sprite[] asteroidSprite;


	void Start () {
		GetComponent<SpriteRenderer>().sprite = asteroidSprite[(int)Random.Range(0f, asteroidSprite.Length)];
		direction = new Vector3 (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), 0f);
		float scale = Random.Range (0.5f, 2f);
		speedRotation = (int)Random.Range (10f, 50f);
		transform.localScale = new Vector3(scale,scale,1f);
	}
	
	void Update () {
		transform.Translate (direction);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag =="Ground") {
			Destroy (this.gameObject);
		}

		if (other.gameObject.tag =="Structure") {
			other.transform.parent.GetComponent<MainConstruct> ().getPart ().destroyConstruction ();
			Destroy (this.gameObject);
		}
	}

}
