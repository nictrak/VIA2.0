using UnityEngine;
using System;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField]
    private Transform equipmentSlotsParent;
    public EquipmentSlot[] EquipmentSlots;
    [SerializeField]
    private int weaponSlotIndex;

    public event Action<ItemSlot> OnRightClickEvent;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    private void Start() {
        for ( int i = 0 ; i < EquipmentSlots.Length ; i++ )
        {
            EquipmentSlots[i].OnRightClickEvent += OnRightClickEvent;
            EquipmentSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            EquipmentSlots[i].OnEndDragEvent += OnEndDragEvent;
            EquipmentSlots[i].OnDragEvent += OnDragEvent;
            EquipmentSlots[i].OnDropEvent += OnDropEvent;
        }
    }

    private void OnValidate()
    {
        EquipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
    }

    public EquippableItem GetEquippedItem(EquipmentType equipmentType)
    {
        for (int i =0; i< EquipmentSlots.Length ; i++)
        {
            if(EquipmentSlots[i].EquipmentType == equipmentType)
            {
                return (EquippableItem) EquipmentSlots[i].Item;
            }
        }
        return null;
    }

    public bool AddItem(EquippableItem item)
    {
        for (int i =0; i< EquipmentSlots.Length ; i++)
        {
            if(EquipmentSlots[i].EquipmentType == item.EquipmentType)
            {
                EquipmentSlots[i].Item = item;
                EquipmentSlots[i].Amount++;
                return true;
            }
        }
        return false;
    }

    public bool SetItem(EquippableItem item, int amount)
    {
        for (int i =0; i< EquipmentSlots.Length ; i++)
        {
            if(EquipmentSlots[i].EquipmentType == item.EquipmentType)
            {
                EquipmentSlots[i].Item = item;
                EquipmentSlots[i].Amount = amount;
                return true;
            }
        }
        return false;
    }

    public bool RemoveItem(EquippableItem item)
    {
        for (int i =0; i< EquipmentSlots.Length ; i++)
        {
            if(EquipmentSlots[i].Item == item)
            {
                EquipmentSlots[i].Amount--;
                if(EquipmentSlots[i].Amount == 0) {
                    EquipmentSlots[i].Item = null;
                }
                return true;
            }
        }
        return false;
    }
    public Weapon GetEquipedWeapon()
    {
        return ((WeaponItem)EquipmentSlots[weaponSlotIndex].Item).weaponPrefab;
    }
    public WeaponItem GetItemWeapon()
    {
        return (WeaponItem)EquipmentSlots[weaponSlotIndex].Item;
    }
}
