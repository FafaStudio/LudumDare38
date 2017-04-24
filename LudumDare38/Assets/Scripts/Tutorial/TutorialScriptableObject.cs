using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] 

public class TutorialScriptableObject : ScriptableObject {
	[SerializeField]
	public List<string> listText;
}