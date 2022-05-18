using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(All_Trim))]
public class AllTrim_Button : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("座標整形"))
        {
            (target as All_Trim).Trim();
            Debug.Log("整形しました。");
        }
    }
}
