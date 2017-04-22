using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldPartUI : MonoBehaviour {
	public Canvas buildingPartInterface;
	public Button upgradeButton;
	public Button removeButton;
	
	public void displayInterface(){
		buildingPartInterface.gameObject.SetActive(true);
	}
	public void undisplayInterface(){
		buildingPartInterface.gameObject.SetActive(false);
	}
}
