using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] 

public class TutorialScriptableObject : ScriptableObject {
	[SerializeField]
	public List<tutoPart> listText;
}

[System.Serializable]
public class tutoPart{
	public string text;
	public bool waitActivation;
}