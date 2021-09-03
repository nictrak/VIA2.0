using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortionController : MonoBehaviour
{
    private ModifierController modifierController;
    private PlayerAttackController playerAttackController;
    // Start is called before the first frame update
    void Start()
    {
        modifierController = GetComponent<ModifierController>();
        playerAttackController = GetComponent<PlayerAttackController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DrinkFromShortcut(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DrinkFromShortcut(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DrinkFromShortcut(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DrinkFromShortcut(3);
        }
    }
    public void DrinkPortion(PortionItem portionItem)
    {
        Debug.Log("Drink " + portionItem);
        if (portionItem != null)
        {
            for (int i = 0; i < portionItem.playerModifiersPrefab.Count; i++)
            {
                modifierController.AddModifier(portionItem.playerModifiersPrefab[i]);
            }
            for (int i = 0; i < portionItem.weaponModifiersPrefab.Count; i++)
            {
                playerAttackController.Weapon.AddModifier(portionItem.weaponModifiersPrefab[i]);
            }
        }
    }
    private void DrinkFromShortcut(int index)
    {
        ShortcutPanel shortcutPanel = GameObject.FindGameObjectWithTag("Shortcut").GetComponent<ShortcutPanel>();
        DrinkPortion((PortionItem)shortcutPanel.ShortcutSlots[index].Item);
    }
}
