using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {
	void Awake(){
		StartCoroutine(win());
	}
	private IEnumerator win()
    {
         yield return new WaitForSeconds(600);
		 youWin();
    }
	public void youWin(){
		GameManager manager = GameManager.instance;
		if((manager.getOxygen()>500)&&(manager.getWood()>1000)&&(manager.getMineral()>3000)&&(manager.getEnergy()>1000)&&(manager.getGem()>500))
			manager.launchWinPanel ();
	}
}
