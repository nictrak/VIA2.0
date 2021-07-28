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
    [Range(1,99)]
    public int MaximunStack = 1;

    private void OnValidate() {
        //string path = AssetDatabase.GetAssetPath(this);
        //id = AssetDatabase.AssetPathToGUID(path);
    }

    public virtual Item Copy() {
        return this;
    }

    public virtual void Destroy() {
        
    } 
}
