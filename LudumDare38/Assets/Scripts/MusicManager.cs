using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioSource[] piste;
	int indicePiste = 1;

	int prevConstructionNumber =0;

	bool battleMusicIsLaunch=false;

	public bool muteMusic=false;

	float chronoBattleMusic = 10f;

	public AudioClip[] music1;
	public AudioClip[] music2;

	int indiceMusic;

	void Start () {
		indiceMusic = (int)Random.Range(1f,3f);
		for (int i = 1; i < piste.Length; i++) {
			piste [i].volume = 0;
		}
		launchMusic ();
	}

	void Update(){
		if (!battleMusicIsLaunch && piste [5].volume > 0f)
			piste [5].volume -= Time.deltaTime;
		if (battleMusicIsLaunch)
			stopBattlePiste ();
		detectEndMusic ();
		fadeEffect ();
		if (muteMusic) {
			for (int i = 0; i < piste.Length; i++) {
				piste [i].volume = 0;
			}
		}
	}

	public void detectEndMusic(){
		for (int i = 0; i < piste.Length; i++) {
			if (!piste [i].isPlaying){
				launchMusic ();
				return;
			}

		}
	}

	public void launchMusic(){
		if (indiceMusic == 1) {
			indiceMusic = 2;
			for (int i = 0; i < piste.Length; i++) {
				piste [i].Stop ();
				piste [i].clip = music2 [i];
				piste [i].Play ();
			}
		} else {
			indiceMusic = 1;
			for (int i = 0; i < piste.Length; i++) {
				piste [i].Stop ();
				piste [i].clip = music1 [i];
				piste [i].Play ();
			}
		}
	}

	public void fadeEffect(){
		for (int i = 0; i < piste.Length; i++) {
			if ((piste [i].volume > 0f) && (piste [i].volume < 0.6f))
				piste [i].volume += Time.deltaTime;
			else if (piste [i].volume > 0.6f)
				piste [i].volume = 0.6f;
				
		}
	}

	public void launchNextPiste(){
		if (indicePiste == piste.Length-1)
			return;
		piste [indicePiste].volume = 0.1f;
		indicePiste++;
	}

	public void launchBatuluPiste(){
		if (battleMusicIsLaunch) {
			chronoBattleMusic += 5f;
			return;
		}
		battleMusicIsLaunch = true;
		piste [5].volume = 0.1f;
	}

	public void stopBattlePiste(){
		chronoBattleMusic -= Time.deltaTime;
		if (chronoBattleMusic <= 0) {
			removeBatuluPiste ();
			chronoBattleMusic = 10f;
		}
	}

	public void removeBatuluPiste(){
		battleMusicIsLaunch = false;
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
