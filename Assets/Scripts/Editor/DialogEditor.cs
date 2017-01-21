using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[CustomEditor(typeof(Dialog))]
public class DialogEditor : Editor {

    Dialog dialog;

    public override void OnInspectorGUI()
    {
        dialog = (Dialog)target;

        dialog.displayName = (Text)EditorGUILayout.ObjectField("Display Name", dialog.displayName, typeof(Text), true);

        dialog.displayText = (Text)EditorGUILayout.ObjectField("Display Text", dialog.displayText, typeof(Text), true);

        dialog.persoName = EditorGUILayout.TextField("Perso Name", dialog.persoName);

        dialog.persoTextSize = EditorGUILayout.FloatField("Perso Text Size", dialog.persoTextSize);
        dialog.persoText = EditorGUILayout.TextArea(dialog.persoText, GUILayout.Height(dialog.persoTextSize));
    }
}
