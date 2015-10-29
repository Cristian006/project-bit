using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This is a Game Manager Script which should take care of everything in game", MessageType.Info);

        DrawDefaultInspector();
        //Here we draw out a bunch more stuff
    }
}
