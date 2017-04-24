using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	float speedRotation;

	public Sprite[] asteroidSprite;

	GameObject worldPart;

	Vector3 origin;
	Vector3 objective;

	float speed;

	void Start () {
		GetComponent<SpriteRenderer>().sprite = asteroidSprite[(int)Random.Range(0f, asteroidSprite.Length)];
		float scale = Random.Range (1f, 2f);
		transform.localScale = new Vector3(scale,scale,1f);
		speedRotation = (int)Random.Range (10f, 50f);
		speed = Random.Range (0.1f, 2f);
		origin = transform.position;
		findWorldPart();
		transform.rotation = Quaternion.Euler(0, 0, worldPart.transform.rotation.eulerAngles.z-75);
		objective = worldPart.GetComponent<WorldPart>().anchor.transform.position;

		//SoundManager.instance.launchSound ("fallinAsteroid");

	}

	void Update () {
		if (transform.position != objective)
			goToWorldPart ();
		else {
			SoundManager.instance.launchSound ("explosionAsteroid");
			Destroy (this.gameObject);
		}
	}

	private void findWorldPart(){
		worldPart = Physics2D.Raycast(transform.position, (new Vector3(0,0) - this.transform.position).normalized, Mathf.Infinity, 1 << 8).collider.gameObject;
	}

	private void goToWorldPart(){
		transform.position = Vector3.MoveTowards(transform.position, objective, speed*Time.deltaTime);
	}

	public void playSound(){
	}

	public void runAway(){
		objective = origin;
		Destroy(gameObject, 20);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag =="Ground") {
			SoundManager.instance.launchSound ("explosionAsteroid");
			Destroy (this.gameObject);
		}
		if (other.gameObject.tag =="Structure") {
			SoundManager.instance.launchSound ("explosionAsteroid");
			other.transform.parent.GetComponent<MainConstruct> ().getPart ().destroyConstruction ();
			Destroy (this.gameObject);
		}
	}

}
