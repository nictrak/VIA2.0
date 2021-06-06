using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierController : MonoBehaviour
{
    [SerializeField]
    private GameObject ModifierPool;
    private PlayerAttackController playerAttackController;

    private Dictionary<string, Modifier> modifiers;
    private Dictionary<string, PortionTime> portions;
    // Start is called before the first frame update
    void Start()
    {
        modifiers = new Dictionary<string, Modifier>();
        portions = new Dictionary<string, PortionTime>();
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
        PortionTime portion = newMod.GetComponent<PortionTime>();
        if (playerAttackController != null)
        {
            if (playerAttackController.IsEquipWeapon()){
                if (playerAttackController.Weapon.IsCanAdd(newMod))
                {
                    Modifier mod = playerAttackController.Weapon.AddModifier(newMod);
                    if(portion != null)
                    {
                        if (portions.ContainsKey(portion.PortionName))
                        {
                            portions[portion.PortionName].ResetTime(portion.TimeFrame);
                        }
                        else
                        {
                            portions.Add(portion.PortionName, mod.GetComponent<PortionTime>());
                        }
                    }
                }
                else
                {
                    if(portion != null)
                    {
                        if (portions.ContainsKey(portion.PortionName))
                        {
                            if(portions[portion.PortionName] != null)
                            {
                                portions[portion.PortionName].ResetTime(portion.TimeFrame);
                            }
                        }
                    }
                }
            }
        }
    }
}
