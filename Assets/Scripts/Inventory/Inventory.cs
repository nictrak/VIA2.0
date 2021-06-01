using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<Item> startingItems;
    [SerializeField]
    private Transform itemsParent;
    [SerializeField]
    private ItemSlot[] itemSlots;

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
        RefeshUI();
    }

    private void OnValidate()
    {
        if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();

        RefeshUI();
    }

    private void RefeshUI()
    {

        int i = 0;
        for(; i < startingItems.Count && i < itemSlots.Length ; i++)
        {
            itemSlots[i].Item = startingItems[i];
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
        /*if(IsFull())
            return false;
        items.Add(item);
        RefeshUI();
        return true;*/
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
        /*if(items.Remove(item)){
            RefeshUI();
            return true;
        }
        return false;*/
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

}
