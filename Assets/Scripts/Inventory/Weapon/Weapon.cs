using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private List<Modifier> modifiersPrefab;
    [SerializeField]
    private List<string> ignoredModifiers;
    public List<Modifier> ModifiersPrefab { get => modifiersPrefab; set => modifiersPrefab = value; }

    // Start is called before the first frame update
    void Start()
    {
        ignoredModifiers = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        ClearAllNull();
        UpdateIgnoredModifiers();
    }
    private void UpdateIgnoredModifiers()
    {
        List<string> newIgnore = new List<string>();
        for (int i = 0; i < modifiersPrefab.Count; i++)
        {
            newIgnore.Add(modifiersPrefab[i].name);
        }
        ignoredModifiers = newIgnore;
    }
    public void ClearAllNull()
    {
        ModifiersPrefab.RemoveAll(mod => mod == null);
    }
    public bool IsCanAdd(Modifier newMod)
    {
        return !ignoredModifiers.Contains(newMod.name);
    }
}
