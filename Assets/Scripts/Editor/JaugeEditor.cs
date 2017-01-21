using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[CustomEditor(typeof(Jauge))]
public class JaugeEditor : Editor {

    Jauge jauge;

    public override void OnInspectorGUI()
    {
        jauge = (Jauge)target;

        jauge.image = (Image)EditorGUILayout.ObjectField("Image", jauge.image, typeof(Image), true);

        jauge.maxVal = EditorGUILayout.FloatField("Max Value", jauge.maxVal);
        if (jauge.maxVal < 0f)
        {
            jauge.maxVal = 0f;
        }

        jauge.activeStartBlinking = EditorGUILayout.BeginToggleGroup("Active Start Blinking", jauge.activeStartBlinking);
        jauge.amountStartBlinking = EditorGUILayout.Slider("Amount Start Blinking", jauge.amountStartBlinking, 0f, jauge.maxVal);
        jauge.freqStartBlinking = EditorGUILayout.FloatField("Freq Start Blinking", jauge.freqStartBlinking);
        jauge.colorStartBlinking = EditorGUILayout.ColorField("Color Start Blinking", jauge.colorStartBlinking);
        EditorGUILayout.EndToggleGroup();

        jauge.activeEndBlinking = EditorGUILayout.BeginToggleGroup("Active End Blinking", jauge.activeEndBlinking);
        jauge.amountEndBlinking = EditorGUILayout.Slider("Amount End Blinking", jauge.amountEndBlinking, 0f, jauge.maxVal);
        jauge.freqEndBlinking = EditorGUILayout.FloatField("Freq End Blinking", jauge.freqEndBlinking);
        jauge.colorEndBlinking = EditorGUILayout.ColorField("Color End Blinking", jauge.colorEndBlinking);
        EditorGUILayout.EndToggleGroup();
    }
}
