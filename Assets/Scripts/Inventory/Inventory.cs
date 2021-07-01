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
    [SerializeField]
    private ItemSlot[] itemSlots;

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
        for ( int i = 0 ; i < itemSlots.Length ; i++ )
        {
            itemSlots[i].OnRightClickEvent += OnRightClickEvent;
            itemSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            itemSlots[i].OnEndDragEvent += OnEndDragEvent;
            itemSlots[i].OnDragEvent += OnDragEvent;
            itemSlots[i].OnDropEvent += OnDropEvent;
        }
    }

    private void OnValidate()
    {
        if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();

        SetStartingItem();
    }

    private void SetStartingItem()
    {

        int i = 0;
        for(; i < startingItems.Count && i < itemSlots.Length ; i++)
        {
            itemSlots[i].Item = Instantiate(startingItems[i]);
        }

        for(;i < itemSlots.Length ; i++)
        {
            itemSlots[i].Item = null;
        }

    }

    public bool IsFull()
    {
        //return items.Count >= itemSlots.Length;
        for (int i =0; i< itemSlots.Length ; i++)
        {
            if(itemSlots[i].Item == null)
            {
                //previousItem = itemSlots[i].Item;
                return false;
            }
        }
        //previousItem = null;
        return true;
    }

    public bool AddItem(Item item){
        for (int i =0; i< itemSlots.Length ; i++)
        {
            if(itemSlots[i].Item == null)
            {
                //previousItem = itemSlots[i].Item;
                itemSlots[i].Item = item;
                return true;
            }
        }
        //previousItem = null;
        return false;
    }

    public bool RemoveItem(Item item){
        for (int i =0; i< itemSlots.Length ; i++)
        {
            if(itemSlots[i].Item == item)
            {
                //previousItem = itemSlots[i].Item;
                itemSlots[i].Item = null;
                return true;
            }
        }
        //previousItem = null;
        return false;
    }

    public Item RemoveItem(string itemID){
        for (int i =0; i< itemSlots.Length ; i++)
        {
            Item item = itemSlots[i].Item;
            if(item != null){
                if(item.ID == itemID)
                {

                    //previousItem = itemSlots[i].Item;
                    itemSlots[i].Item = null;
                    return item;
                }
            }
        }
        //previousItem = null;
        return null;
    }

}
