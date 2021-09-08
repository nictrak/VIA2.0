using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private int _money;
    [SerializeField]
    private List<Item> startingItems;
    [SerializeField]
    private Transform itemsParent;
    public ItemSlot[] ItemSlots;

    public int Money {
        get { return _money; }
        set {
            _money = value;
            if(_money < 0){
                _money = 0;
            } else if (_money > 9999){
                _money = 9999;
            }
        }
    }

    public event Action<ItemSlot> OnRightClickEvent;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    private void Start() {
        for ( int i = 0 ; i < ItemSlots.Length ; i++ )
        {
            ItemSlots[i].OnRightClickEvent += OnRightClickEvent;
            ItemSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            ItemSlots[i].OnEndDragEvent += OnEndDragEvent;
            ItemSlots[i].OnDragEvent += OnDragEvent;
            ItemSlots[i].OnDropEvent += OnDropEvent;
        }
    }

    private void OnValidate()
    {
        if (itemsParent != null)
            ItemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();

        SetStartingItem();
    }

    private void SetStartingItem()
    {

        int i = 0;
        for(; i < startingItems.Count && i < ItemSlots.Length ; i++)
        {
            ItemSlots[i].Item = startingItems[i].Copy();
            ItemSlots[i].Amount = 1;
        }

        for(;i < ItemSlots.Length ; i++)
        {
            ItemSlots[i].Item = null;
            ItemSlots[i].Amount = 0;
        }

    }

    public bool IsFull()
    {
        //return items.Count >= itemSlots.Length;
        for (int i =0; i< ItemSlots.Length ; i++)
        {
            if(ItemSlots[i].Item == null)
            {
                //previousItem = itemSlots[i].Item;
                return false;
            }
        }
        //previousItem = null;
        return true;
    }

    public bool AddItem(Item item){
        for (int i =0; i< ItemSlots.Length ; i++)
        {
            if(ItemSlots[i].Item == null || (ItemSlots[i].Item.ID == item.ID && ItemSlots[i].Amount < ItemSlots[i].Item.MaximunStack))
            {
                //previousItem = itemSlots[i].Item;
                ItemSlots[i].Item = item;
                ItemSlots[i].Amount++;
                return true;
            }
        }
        //previousItem = null;
        return false;
    }

    public bool RemoveItem(Item item, int Amount = 1){

        if(ContainItem(item, Amount))
        {
            int remainingRemoveAmount = Amount;
            for (int i =0; i< ItemSlots.Length ; i++)
            {
                if(ItemSlots[i].Item == item)
                {
                    if(ItemSlots[i].Amount >= remainingRemoveAmount)
                    {
                        ItemSlots[i].Amount -= remainingRemoveAmount;
                        if(ItemSlots[i].Amount == 0) {
                            ItemSlots[i].Item = null;
                        }
                        return true;
                    } else {
                        remainingRemoveAmount -= ItemSlots[i].Amount;
                        ItemSlots[i].Amount = 0;
                        ItemSlots[i].Item = null;
                    }
                }
            }
        }
        //previousItem = null;
        return false;

    }

    public bool ContainItem(Item item, int Amount = 1){
        int count = 0;
        for (int i =0; i< ItemSlots.Length ; i++)
        {
            if(ItemSlots[i].Item == item)
            {
                count += ItemSlots[i].Amount;
            }
            if(count >= Amount){
                return true;
            }
        }
        return false;
    }

    public Item RemoveItem(string itemID){
        for (int i =0; i< ItemSlots.Length ; i++)
        {
            Item item = ItemSlots[i].Item;
            if(item != null){
                if(item.ID == itemID)
                {
                    //previousItem = itemSlots[i].Item;
                    ItemSlots[i].Amount--;
                    if(ItemSlots[i].Amount == 0) {
                        ItemSlots[i].Item = null;
                    }
                    return item;
                }
            }
        }
        //previousItem = null;
        return null;
    }

}
