using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainConstructUpgradeEditorScript {
	[MenuItem("Assets/Create/EditorUtils/MainConstruct")]
	public static void CreateAsset ()
	{
		
        MainConstructScriptableObject asset = ScriptableObject.CreateInstance<MainConstructScriptableObject>();

        AssetDatabase.CreateAsset(asset, "Assets/Prefabs/MainConstructs/MainConstructUpgrades.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
	}
}
