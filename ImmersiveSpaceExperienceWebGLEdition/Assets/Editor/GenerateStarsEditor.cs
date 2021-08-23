using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GenerateStars))]
public class GenerateStarsEditor : Editor
{
    public GameObject source;

    public override void OnInspectorGUI() {
        GenerateStars generateStarsScript = (GenerateStars) target;

        generateStarsScript.numStars = EditorGUILayout.IntField("Number of Stars", generateStarsScript.numStars);
        generateStarsScript.star = (GameObject)EditorGUILayout.ObjectField("Star", generateStarsScript.star, typeof(GameObject), true);
        generateStarsScript.minSpeed = EditorGUILayout.FloatField("Minimum Speed", generateStarsScript.minSpeed);
        generateStarsScript.maxSpeed = EditorGUILayout.FloatField("Maximum Speed", generateStarsScript.maxSpeed);
        generateStarsScript.minDistance = EditorGUILayout.FloatField("Minimum Distance", generateStarsScript.minDistance);
        generateStarsScript.maxDistance = EditorGUILayout.FloatField("Maximum Distance", generateStarsScript.maxDistance);

        if(GUILayout.Button("Generate Stars"))
        {
            generateStarsScript.Generate();
        }
    }
}
