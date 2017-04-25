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
		if(GameManager.instance.isDebugVersion)
			yield return new WaitForSeconds (5f);
		else
        	 yield return new WaitForSeconds(600);
		 youWin();
    }
	public void youWin(){
		MusicManager.instance.launchWin ();
		GameManager manager = GameManager.instance;
		manager.setEndGame (true);
		manager.launchWinPanel ();
	}
}
