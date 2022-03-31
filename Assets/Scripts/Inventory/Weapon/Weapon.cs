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
    private bool isSummonWeapon;
    [SerializeField]

    [Header("Attact Effect")]
    private AttackEffectInput attackEffect;
    public AttackEffectInput AttackEffect { get { return attackEffect; } }
    [SerializeField]
    private float knockBackPower = 0f;
    public KnockbackInput KnockbackInput { 
        get {
            if(knockBackPower <= 0f) return null;
            return new KnockbackInput(transform.position, knockBackPower); 
        }
    }

    private bool summonWeapon;
    public List<Modifier> ModifiersPrefab { get => modifiersPrefab; set => modifiersPrefab = value; }
    public List<Attack> AttackObjects { get => attackObjects; set => attackObjects = value; }
    public List<string> AttackStrings { get => attackStrings; set => attackStrings = value; }
    public GameObject SpecialAttackPool { get => specialAttackPool; set => specialAttackPool = value; }

    // Start is called before the first frame update
    void Start()
    {
        ignoredModifiers = new List<string>();
        summonWeapon = isSummonWeapon;
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
        return summonWeapon;
    }
    void OnDestroy()
    {
        if (summonWeapon){
            Debug.Log("OnDestroy Weapon Summon");
            InventoryManager inventoryManager = GameObject.FindGameObjectWithTag("inventoryPanel").GetComponent<InventoryManager>();
            inventoryManager.EquipmentPanel.RemoveItem(inventoryManager.EquipmentPanel.GetItemWeapon());

            inventoryManager.EquipmentPanel.ReEquipWeaponFromSummon();
        }
        
    }
}
