using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private List<Modifier> modifiersPrefab;
    [SerializeField]
    private List<string> ignoredModifiers;
    [SerializeField]
    private List<string> attackStrings;
    [SerializeField]
    private List<Attack> attackObjects;
    [SerializeField]
    private GameObject specialAttackPool;
    [SerializeField]
    private bool isSommonWeapon;

    private bool sommonWeapon;
    public List<Modifier> ModifiersPrefab { get => modifiersPrefab; set => modifiersPrefab = value; }
    public List<Attack> AttackObjects { get => attackObjects; set => attackObjects = value; }
    public List<string> AttackStrings { get => attackStrings; set => attackStrings = value; }
    public GameObject SpecialAttackPool { get => specialAttackPool; set => specialAttackPool = value; }

    // Start is called before the first frame update
    void Start()
    {
        ignoredModifiers = new List<string>();
        sommonWeapon = isSommonWeapon;
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
            newIgnore.Add(modifiersPrefab[i].ModName);
        }
        ignoredModifiers = newIgnore;
    }
    public void ClearAllNull()
    {
        ModifiersPrefab.RemoveAll(mod => mod == null);
    }
    public bool IsCanAdd(Modifier newMod)
    {
        return !ignoredModifiers.Contains(newMod.ModName);
    }
    public Modifier AddModifier(Modifier newMod)
    {
        if (IsCanAdd(newMod))
        {
            Modifier spawned = Instantiate<Modifier>(newMod, transform.transform);
            modifiersPrefab.Add(spawned);
            return spawned;
        }
        return null;
    }

    public bool IsSummonWeapon()
    {
        return sommonWeapon;
    }
}
