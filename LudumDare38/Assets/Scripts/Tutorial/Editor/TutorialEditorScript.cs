using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class TutorialEditorScript {
	[MenuItem("Assets/Create/EditorUtils/TutorialTexts")]
	public static void CreateAsset ()
	{
		
        TutorialScriptableObject asset = ScriptableObject.CreateInstance<TutorialScriptableObject>();

        AssetDatabase.CreateAsset(asset, "Assets/Scripts/Tutorial/TutorialTexts.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
	}
}
