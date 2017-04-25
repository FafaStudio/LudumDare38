using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienCounterSecondary : MonoBehaviour {
	SecondaryConstruct mainConstruct;
	WorldController worldController;

	public int AreaRange;
	// Use this for initialization
	void Awake () {
		worldController = WorldController.instance;
		mainConstruct = GetComponent<SecondaryConstruct>();
		StartCoroutine(WaitAtAwake());
	}
	
	void OnDestroy() {
		removeEffect();
	}
	IEnumerator WaitAtAwake()
    {
        yield return new WaitForSeconds(1);
        applyEffect();
    }
	private void applyEffect(){
		int index = mainConstruct.getPart().getIndex();
		mainConstruct.getPart().addAlienCounter();
		for(var i = 0; i < AreaRange; i++){
			int tempIndex = index+1;
			if(tempIndex>= 24){
				tempIndex = tempIndex-24;
			}
			worldController.worldParts[tempIndex].addAlienCounter();

			int tempIndex2 = index-1;
			if(tempIndex2 < 0){
				tempIndex2 = 24 + tempIndex2;
			}
			worldController.worldParts[tempIndex2].addAlienCounter();
		}
	}
	private void removeEffect(){
		int index = mainConstruct.getPart().getIndex();
		mainConstruct.getPart().removeAlienCounter();
		for(var i = 0; i < AreaRange; i++){
			int tempIndex = index+1;
			if(tempIndex>= 24){
				tempIndex = tempIndex-24;
			}
			worldController.worldParts[tempIndex].removeAlienCounter();

			int tempIndex2 = index-1;
			if(tempIndex2 < 0){
				tempIndex2 = 24 + tempIndex2;
			}
			worldController.worldParts[tempIndex2].removeAlienCounter();
		}
	}
}
