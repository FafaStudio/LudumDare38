using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundUI : MonoBehaviour {

	public void OnMouseEnter() {
		SoundManager.instance.launchSound ("overUI");
	}

	public void OnClick(){
		SoundManager.instance.launchSound ("clickUI");
	}


}
