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

    public override Item Copy() {
        return Instantiate(this);
    }

    public override void Destroy() {
        Destroy(this);
    } 
}
