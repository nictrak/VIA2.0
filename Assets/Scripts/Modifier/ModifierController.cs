using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierController : MonoBehaviour
{
    [SerializeField]
    private GameObject ModifierPool;
    private PlayerAttackController playerAttackController;

    private Dictionary<string, Modifier> modifiers;
    // Start is called before the first frame update
    void Start()
    {
        modifiers = new Dictionary<string, Modifier>();
        playerAttackController = GetComponent<PlayerAttackController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddModifier(Modifier newMod)
    {
        if (modifiers.ContainsKey(newMod.ModName))
        {
            modifiers[newMod.ModName].ResetTime(newMod.TimeFrame);
        }
        else
        {
            Modifier spawned = Instantiate<Modifier>(newMod, ModifierPool.transform);
            spawned.IsEnable = true;
            modifiers.Add(spawned.ModName, spawned);
        }
    }
    public void AddWeaponModifier(Modifier newMod)
    {
        if (playerAttackController != null)
        {
            if(playerAttackController.IsEquipWeapon()) playerAttackController.Weapon.AddModifier(newMod);
        }
    }
}
