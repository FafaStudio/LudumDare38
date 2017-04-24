using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource[] piste;

	public AudioClip[] constructionSound;
	public AudioClip[] menaceSound;

	public AudioClip recuperationRessourceVolante;

	public AudioClip[] soundPartUI;

	public void launchSound(string sound){
		for (int i = 0; i < piste.Length; i++) {
			if ((!piste [i].isPlaying)||(piste[i].clip==null)) {
				prepareSound (piste [i], sound);
				return;
			}
		}
	}

	public void prepareSound(AudioSource source, string audioClip){
		source.loop = false;
		switch (audioClip) {
			case "constructionUsine":
				source.clip = constructionSound [0];
				break;
			case "constructionDefense":
				source.clip = constructionSound [1];
				break;
			case "constructionSecondaire":
				source.clip = constructionSound [2];
				break;
			case "constructionFusée":
				source.clip = constructionSound [3];
				break;
			case "constructionConsommable":
				source.clip = constructionSound [4];
				break;
			case "menaceGuepe":
				source.clip = menaceSound [0];
				break;
		case "fallinAsteroid":
			source.clip = menaceSound [2];
			break;
			case "explosionAsteroid":
				source.clip = menaceSound [1];
				break;
		case "Eruption":
			source.clip = menaceSound [3];
			break;

			case "getRessource":
				source.clip = recuperationRessourceVolante;
				break;
		case "upgradeMainUI":
			source.clip = soundPartUI[0];
			break;
		case "removeMainUI":
			source.clip = soundPartUI[1];
			break;
		}
		source.Play ();
	}

	private static SoundManager s_Instance = null;

	// This defines a static instance property that attempts to find the manager object in the scene and
	// returns it to the caller.
	public static SoundManager instance
	{
		get
		{
			if (s_Instance == null)
			{
				// This is where the magic happens.
				//  FindObjectOfType(...) returns the first AManager object in the scene.
				s_Instance = FindObjectOfType(typeof(SoundManager)) as SoundManager;
			}

			// If it is still null, create a new instance
			if (s_Instance == null)
			{
				GameObject obj = Instantiate(Resources.Load("SoundManager") as GameObject);
				s_Instance = obj.GetComponent<SoundManager>();
			}
			return s_Instance;
		}
	}
}
