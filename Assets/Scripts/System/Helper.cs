using UnityEngine;
using UnityEditor;

public static class Helper
{
    public static T[] FindAssetsByType<T>(params string[] folders) where T : Object
    {
        string type = typeof(T).ToString().Replace("UnityEngine.", "");
        string[] guids;// = AssetDatabase.FindAssets("t:" + type, );
        if(folders == null || folders.Length == 0)
        {
            guids = AssetDatabase.FindAssets("t:" + type);
        } else {
            guids = AssetDatabase.FindAssets("t:" + type, folders);
        }

        T[] assets = new T[guids.Length];

        for(int i = 0; i< guids.Length; i++)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
            assets[i] = AssetDatabase.LoadAssetAtPath<T>(assetPath);
        }
        return assets;
    }
}
