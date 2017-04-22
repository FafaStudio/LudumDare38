using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SecondaryConstructUpgradeEditorScript {
	[MenuItem("Assets/Create/EditorUtils/SecondaryConstruct")]
	public static void CreateAsset ()
	{
		
        SecondaryConstructScriptableObject asset = ScriptableObject.CreateInstance<SecondaryConstructScriptableObject>();

        AssetDatabase.CreateAsset(asset, "Assets/Prefabs/SecondaryConstructs/SecondaryConstructUpgrades.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
	}
}
