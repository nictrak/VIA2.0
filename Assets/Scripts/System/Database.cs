using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public abstract class Database : ScriptableObject
{
    #if UNITY_EDITOR
    private void OnValidate() {
        LoadItems();
    }

    private void OnEnable() {
        EditorApplication.projectChanged += LoadItems;
    }

    private void OnDisable() {
        EditorApplication.projectChanged -= LoadItems;
    }

    protected abstract void LoadItems();
    #endif
}
