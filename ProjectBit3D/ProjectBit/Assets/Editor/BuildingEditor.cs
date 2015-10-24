using UnityEngine;
using UnityEditor;

public class BuildingEditor : EditorWindow
{ 
    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/Building Editor")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(BuildingEditor));
    }

    void OnGUI()
    {
        GUILayout.Label("Building Editor", EditorStyles.boldLabel);
    }
}
