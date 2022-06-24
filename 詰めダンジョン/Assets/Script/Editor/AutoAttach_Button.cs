using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Auto_Attach))]
public class AutoAttach_Button : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("自動アタッチ")){
            (target as Auto_Attach).Attach();
        }
    }
}
