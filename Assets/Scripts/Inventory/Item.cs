using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Item", menuName = "VIA2.0/Item", order = 0)]
public class Item : ScriptableObject
{
    [SerializeField]
    private string id;
    public string ID { get { return id; } }
    public string Name;
    public Sprite Icon;

    private void OnValidate() {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
    }
}
