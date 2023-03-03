using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomPropertyDrawer(typeof(MainTime))]
public class MainTimePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty hour = property.FindPropertyRelative("hour");
        SerializedProperty minute = property.FindPropertyRelative("minute");
        SerializedProperty second = property.FindPropertyRelative("second");


        List<string> time = new List<string>
        {
            hour.intValue.ToString(),
            minute.intValue.ToString(),
            second.intValue.ToString(),
        };

        for (int i = 0; i < time.Count; i++)
        {
            if (time[i].Length == 1)
            {
                time[i] = time[i].PadLeft(2, '0');
            }
        }

        EditorGUI.LabelField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight),"Time: ", $"{time[0]}:{time[1]}:{time[2]}");
        EditorGUI.EndProperty();
    }
}