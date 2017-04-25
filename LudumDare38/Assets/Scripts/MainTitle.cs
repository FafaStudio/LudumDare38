using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTitle : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		if (Input.anyKey)
			launchGame ();
	}

	public void launchGame(){
		Application.LoadLevel ("mainHugo");
	}
}
