using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {
	void Start(){
		if(transform.parent.name == "Menu"){
			return;
		}
		StartCoroutine(win());
	}
	private IEnumerator win()
    {
         yield return new WaitForSeconds(5);
		 youWin();
    }
	public void youWin(){
		GameManager manager = GameManager.instance;
		manager.launchWinPanel ();
	}
}
