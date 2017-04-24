using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorlogeScript : MonoBehaviour {

	GameManager manager;
	Image horloge;

	void Start () {
		manager = GameManager.instance;
		horloge = GetComponent<Image> ();
	}

	void Update () {
		horloge.fillAmount = 1 - (manager.getTimePassed()/manager.getDayDuration());
	}
}
