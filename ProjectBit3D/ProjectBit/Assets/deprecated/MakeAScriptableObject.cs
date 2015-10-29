using UnityEngine;
using UnityEditor;
using System.Collections;

public class MakeAScriptableObject {
    [MenuItem("Assets/Create/GridScriptableObject")]
	public static void CreateMyAsset()
    {
        GridScriptableObjectClass asset = ScriptableObject.CreateInstance<GridScriptableObjectClass>();
        AssetDatabase.CreateAsset(asset, "Assets/Scripts/Experimental/gridScriptableObject.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
    }
}
