using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioSource[] piste;
	int indicePiste = 1;

	int prevConstructionNumber =0;

	public bool muteMusic=false;

	void Start () {
		for (int i = 1; i < piste.Length; i++) {
			piste [i].volume = 0;
		}
	}

	void Update(){
		fadeEffect ();
		if (muteMusic) {
			for (int i = 0; i < piste.Length; i++) {
				piste [i].volume = 0;
			}
		}
	}

	public void fadeEffect(){
		for (int i = 0; i < piste.Length; i++) {
			if ((piste [i].volume > 0f) && (piste [i].volume < 0.8f))
				piste [i].volume += Time.deltaTime;
			else if (piste [i].volume > 0.8f)
				piste [i].volume = 0.8f;
				
		}
	}

	public void launchNextPiste(){
		if (indicePiste == piste.Length-1)
			return;
		piste [indicePiste].volume = 0.1f;
		indicePiste++;
	}

	public void launchBatuluPiste(){
		piste [indicePiste - 1].volume = 0.1f;
	}

	public void removeBatuluPiste(){
		piste [indicePiste - 1].volume = 0f;
	}

	public void removePiste(){
		if (indicePiste == 1)
			return;
		indicePiste--;
		piste [indicePiste].volume = 0f;
	}

	public void verifyPiste(int constructionNumber){
		if (constructionNumber % 1 == 0) {
			int calculTest = constructionNumber - prevConstructionNumber;
			if (calculTest > 0) {
				launchNextPiste ();
			} else
				removePiste ();
		}
		prevConstructionNumber = constructionNumber;
	}

	private static MusicManager s_Instance = null;

	// This defines a static instance property that attempts to find the manager object in the scene and
	// returns it to the caller.
	public static MusicManager instance
	{
		get
		{
			if (s_Instance == null)
			{
				// This is where the magic happens.
				//  FindObjectOfType(...) returns the first AManager object in the scene.
				s_Instance = FindObjectOfType(typeof(MusicManager)) as MusicManager;
			}

			// If it is still null, create a new instance
			if (s_Instance == null)
			{
				GameObject obj = Instantiate(Resources.Load("MusicManager") as GameObject);
				s_Instance = obj.GetComponent<MusicManager>();
			}
			return s_Instance;
		}
	}
}
