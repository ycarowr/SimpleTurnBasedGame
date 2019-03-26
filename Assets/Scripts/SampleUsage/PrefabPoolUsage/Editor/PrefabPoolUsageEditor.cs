using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PrefabPoolUsage))]
public class PrefabPoolUsageEditor : Editor
{
    private PrefabPoolUsage Target => target as PrefabPoolUsage;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (!Application.isPlaying)
            return;

        if (GUILayout.Button("Pool"))
            Target.PoolRandomObject();

        if (GUILayout.Button("Release"))
            Target.ReleaseRandomChild();
    }
}