using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MaxAngularChanger))]
public class MaxAngVelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MaxAngularChanger victim = (MaxAngularChanger)target;
        if(DrawDefaultInspector())
        {
            victim.UpdateValues();
        }
    }
}
