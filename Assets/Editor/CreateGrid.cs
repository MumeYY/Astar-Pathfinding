using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Grid))]
public class ObjectBuilderEditor : Editor
{
    

    public override void OnInspectorGUI()
    {
        
        DrawDefaultInspector();
        Grid myScript = (Grid)target;
        GUILayout.Space(10);

        if (Grid.instance.grid.values != null) {
            GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
            centeredStyle.alignment = TextAnchor.MiddleCenter;
            centeredStyle.fontSize = 15;
            centeredStyle.richText = true;
            GUILayout.Label("<b>Current grid size:</b> " + Grid.instance.grid.values.Length, centeredStyle);
            centeredStyle.fontSize = 12;
            centeredStyle.richText = false;

            GUILayout.Label("Width: " + Grid.instance.grid.Width + " Height: " + Grid.instance.grid.Height, centeredStyle);

        }
        if (GUILayout.Button("Test grid"))
        {
            myScript.CreateGrid();
            EditorUtility.SetDirty(myScript);
        }
        if (GUILayout.Button("Test dictonary"))
        {
            myScript.AddWalkableRegionsToDictonary();
            EditorUtility.SetDirty(myScript);
        }
    }
}

public class ReadOnlyAttribute : PropertyAttribute
{

}

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property,
                                            GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position,
                               SerializedProperty property,
                               GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
}