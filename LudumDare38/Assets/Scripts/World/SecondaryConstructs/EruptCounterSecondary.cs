using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EruptCounterSecondary : MonoBehaviour {
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
		mainConstruct.getPart().addEruptionCounter();
		for(var i = 0; i < AreaRange; i++){
			int tempIndex = index+1;
			if(tempIndex>= 24){
				tempIndex = tempIndex-24;
			}
			worldController.worldParts[tempIndex].addEruptionCounter();

			int tempIndex2 = index-1;
			if(tempIndex2 < 0){
				tempIndex2 = 24 + tempIndex2;
			}
			worldController.worldParts[tempIndex2].addEruptionCounter();
		}
	}
	private void removeEffect(){
		int index = mainConstruct.getPart().getIndex();
		mainConstruct.getPart().removeEruptionCounter();
		for(var i = 0; i < AreaRange; i++){
			int tempIndex = index+1;
			if(tempIndex>= 24){
				tempIndex = tempIndex-24;
			}
			worldController.worldParts[tempIndex].removeEruptionCounter();

			int tempIndex2 = index-1;
			if(tempIndex2 < 0){
				tempIndex2 = 24 + tempIndex2;
			}
			worldController.worldParts[tempIndex2].removeEruptionCounter();
		}
	}
}
