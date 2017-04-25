using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemUI : MonoBehaviour {

	bool showUi= false;

	bool mutedSound = false;

	public GameObject mainButton;
	public GameObject optionUI;

	public Toggle mutedToggle;

	void Start () {
		optionUI.SetActive (false);
	}

	void Update () {
		
	}

	public void switchConfig(){
		if (showUi) {
			mainButton.SetActive (true);
			optionUI.SetActive (false);
		} else {
			mainButton.SetActive (false);
			optionUI.SetActive (true);
		}
		showUi = !showUi;
	}

	public void switchSoundMuted(){
		mutedSound = !mutedSound;
		if (mutedSound) {
			SoundManager.instance.relaunchSound ();
			MusicManager.instance.relaunchMusic ();
		} else {
			SoundManager.instance.soundMuted ();
			MusicManager.instance.musicMuted ();
		}
	}
}
