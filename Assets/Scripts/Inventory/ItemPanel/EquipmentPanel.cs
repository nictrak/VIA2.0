using UnityEngine;
using System;

public class EquipmentPanel : ItemPanel<EquipmentSlot>
{

    #if UNITY_EDITOR
    protected override void OnValidate()
    {
        base.OnValidate();
    }
    #endif

    #region Override
    public override bool SetItem(ItemSlot[] itemSlots)
    {
        EquipmentSlot[] prevItemSlots = (EquipmentSlot[])this.ItemSlots.Clone();

        if(base.SetItem(itemSlots) && (ItemSlots.Length == Enum.GetNames(typeof(EquipmentType)).Length)){
            return true;
        }

        this.ItemSlots = prevItemSlots;
        return false;
    }

    #endregion

    public EquippableItem GetEquippedItem(EquipmentType equipmentType)
    {
        for (int i =0; i< ItemSlots.Length ; i++)
        {
            if(ItemSlots[i].EquipmentType == equipmentType)
            {
                return (EquippableItem) ItemSlots[i].Item;
            }
        }
        return null;
    }

}
