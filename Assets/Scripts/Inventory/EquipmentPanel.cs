using UnityEngine;
using System;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField]
    private Transform equipmentSlotsParent;
    [SerializeField]
    private EquipmentSlot[] equipmentSlots;
    [SerializeField]
    private int weaponSlotIndex;

    public event Action<ItemSlot> OnRightClickEvent;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    private void Start() {
        for ( int i = 0 ; i < equipmentSlots.Length ; i++ )
        {
            equipmentSlots[i].OnRightClickEvent += OnRightClickEvent;
            equipmentSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            equipmentSlots[i].OnEndDragEvent += OnEndDragEvent;
            equipmentSlots[i].OnDragEvent += OnDragEvent;
            equipmentSlots[i].OnDropEvent += OnDropEvent;
        }
    }

    private void OnValidate()
    {
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
    }

    public bool AddItem(EquippableItem item, out EquippableItem previousItem)
    {
        for (int i =0; i< equipmentSlots.Length ; i++)
        {
            if(equipmentSlots[i].EquipmentType == item.EquipmentType)
            {
                previousItem = (EquippableItem) equipmentSlots[i].Item;
                equipmentSlots[i].Item = item;
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(EquippableItem item)
    {
        for (int i =0; i< equipmentSlots.Length ; i++)
        {
            if(equipmentSlots[i].Item == item)
            {
                equipmentSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }
    public Weapon GetEquipedWeapon()
    {
        return ((WeaponItem)equipmentSlots[weaponSlotIndex].Item).weaponPrefab;
    }
    public WeaponItem GetItemWeapon()
    {
        return (WeaponItem)equipmentSlots[weaponSlotIndex].Item;
    }
}
