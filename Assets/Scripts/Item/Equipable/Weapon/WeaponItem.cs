using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Item", menuName = "VIA2.0/Items/Weapon Item")]
public class WeaponItem : EquippableItem, IShortcutable
{
    [SerializeField]
    private Weapon weaponPrefab;
    public Weapon WeaponPrefab { get => weaponPrefab; }

    public bool CanUse()
    {
        return true;
    }

    public int Use(bool isRightClick)
    {
        PlayerMoveController.current.WeaponUsedHandler(isRightClick);
        return 0;
    }

}
