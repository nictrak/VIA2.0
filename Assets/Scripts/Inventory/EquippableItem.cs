using UnityEngine;

public enum EquipmentType
{
    Weapon,
    Armour
}

[CreateAssetMenu(fileName = "New Equippable Item", menuName = "VIA2.0/Equippable Item", order = 0)]
public class EquippableItem : Item
{
    public EquipmentType EquipmentType;
}
