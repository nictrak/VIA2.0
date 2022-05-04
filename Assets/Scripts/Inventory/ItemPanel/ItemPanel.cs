using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ItemPanel<K> : MonoBehaviour 
    where K : ItemSlot
{

    [SerializeField]
    protected Transform itemsParent;
    public K[] ItemSlots;

    public event Action<ItemSlot> OnRightClickEvent;
    public event Action<ItemSlot> OnLeftClickEvent;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    protected virtual void Start() {
        for ( int i = 0 ; i < ItemSlots.Length ; i++ )
        {
            ItemSlots[i].OnRightClickEvent += OnRightClickEvent;
            ItemSlots[i].OnLeftClickEvent += OnLeftClickEvent;
            ItemSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            ItemSlots[i].OnEndDragEvent += OnEndDragEvent;
            ItemSlots[i].OnDragEvent += OnDragEvent;
            ItemSlots[i].OnDropEvent += OnDropEvent;
        }
    }

    #if UNITY_EDITOR
    protected virtual void OnValidate()
    {
        if (itemsParent != null)
            ItemSlots = itemsParent.GetComponentsInChildren<K>();
    }
    #endif

    public virtual bool SetItem(ItemSlot[] itemSlots){

        ItemSlots = (K[])itemSlots.Clone();
        return true;

    }

    public virtual int CountItem(string itemID){

        int count = 0;
        for (int i = 0; i < ItemSlots.Length; i++)
        {
            Item item = ItemSlots[i].Item;
            if (item != null)
            {
                if (item.ID == itemID)
                {
                    count += ItemSlots[i].Amount;
                }
            }
        }
        return count;

    }

    public virtual bool HaveItem(string itemID){

        for (int i = 0; i < ItemSlots.Length; i++)
        {
            Item item = ItemSlots[i].Item;
            if (item != null)
            {
                if (item.ID == itemID)
                {
                    return true;
                }
            }
        }
        return false;

    }

}
