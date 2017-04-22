using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondaryConstructUI : MonoBehaviour {
	public Builder builder;
	public SecondaryConstruct secondaryConstruct;
	public Text description;
	void Awake(){
		description.text = secondaryConstruct.constructDescription;
	}

	public void instantiate(){
		if(builder.getActualPart().canSecondaryConstruct()){
			builder.getActualPart().addSecondaryConstruct(secondaryConstruct);
		}
	}
}
