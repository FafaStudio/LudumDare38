﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainConstructUI : MonoBehaviour {
	public Builder builder;
	public GameObject mainContruct;
	public Text description;
	void Awake(){
		builder = Builder.instance;
		description.text = mainContruct.GetComponent<MainConstruct>().constructDescription;
	}

	public void instantiate(){
		if(builder.getActualPart().canMainConstruct()){
			if(mainContruct.GetComponent<MainConstruct>().haveEnoughtResources()){
				builder.getActualPart().addMainConstruct(mainContruct);
			}
		}
	}
}
