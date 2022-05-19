using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StageMaker))]
public class StageMaker_Button : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("ランダムにステージを作成"))
        {
            (target as StageMaker).Make();
        }

    }
}
