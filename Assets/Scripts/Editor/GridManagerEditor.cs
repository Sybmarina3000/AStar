using System.Collections;
using System.Collections.Generic;
using DisplayMap;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridMapEditor))]
public class GridManagerEditor : Editor{
    // Start is called before the first frame update

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate map (in Edit Mode)"))
        {
            ((GridMapEditor) target).BuildGrid();
        }
    }
}
