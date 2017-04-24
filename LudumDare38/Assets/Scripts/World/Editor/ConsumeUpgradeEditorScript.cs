using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ConsumeUpgradeEditorScript {
	[MenuItem("Assets/Create/EditorUtils/Consumable")]
	public static void CreateAsset ()
	{
		
        ConsumableScriptableObject asset = ScriptableObject.CreateInstance<ConsumableScriptableObject>();

        AssetDatabase.CreateAsset(asset, "Assets/Prefabs/Consumable/Consumable.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
	}
}
