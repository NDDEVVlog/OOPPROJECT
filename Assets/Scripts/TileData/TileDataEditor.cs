using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//[CustomEditor(typeof(TileData))]
public class TileDataEditor : Editor
{

    private SerializedProperty tileDataSetProp;
    private TileDataSet tileDataSet;

    private void OnEnable()
    {
        tileDataSetProp = serializedObject.FindProperty("tileDataSet");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("tiles"), true);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Tile Data Set:");

        EditorGUI.indentLevel++;

        int arraySize = tileDataSetProp.arraySize;
        arraySize = EditorGUILayout.IntField("Size", arraySize);

        if (arraySize != tileDataSetProp.arraySize)
        {
            while (arraySize > tileDataSetProp.arraySize)
            {
                tileDataSetProp.InsertArrayElementAtIndex(tileDataSetProp.arraySize);
            }
            while (arraySize < tileDataSetProp.arraySize)
            {
                tileDataSetProp.DeleteArrayElementAtIndex(tileDataSetProp.arraySize - 1);
            }
        }

        for (int i = 0; i < tileDataSetProp.arraySize; i++)
        {
            var element = tileDataSetProp.GetArrayElementAtIndex(i);
            var tileProp = element.FindPropertyRelative("tile");
            var canBeDestoryProp = element.FindPropertyRelative("canBeDestory");

            EditorGUILayout.PropertyField(tileProp);
            EditorGUILayout.PropertyField(canBeDestoryProp);
        }

        EditorGUI.indentLevel--;

        serializedObject.ApplyModifiedProperties();
    }
}
