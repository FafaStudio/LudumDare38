using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour {
	[SerializeField]
	public List<Button> buttonToDeactiveWithoutHome;
	// Use this for initialization
	public void setActive(bool boolean){

		buttonToDeactiveWithoutHome[0].interactable = !boolean;
		buttonToDeactiveWithoutHome[0].transform.FindChild("descriptionContainer").gameObject.SetActive(false);
		buttonToDeactiveWithoutHome[0].gameObject.GetComponent<EventTrigger>().enabled = !boolean;
		for (int i = 1; i < buttonToDeactiveWithoutHome.Count; i++)
		{
			buttonToDeactiveWithoutHome[i].interactable = boolean;
			buttonToDeactiveWithoutHome[i].gameObject.GetComponent<EventTrigger>().enabled = boolean;
		}
	}
}
