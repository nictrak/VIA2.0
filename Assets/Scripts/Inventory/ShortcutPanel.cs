using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShortcutPanel : MonoBehaviour
{
    [SerializeField]
    private Transform shortcutSlotsParent;
    [SerializeField]
    private ItemSlot[] shortcutSlots;

    public ItemSlot[] ShortcutSlots { get => shortcutSlots; set => shortcutSlots = value; }

    public event Action<ItemSlot> OnRightClickEvent;
    public event Action<ItemSlot> OnLeftClickEvent;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnDropEvent;
    private void Start()
    {
        for (int i = 0; i < shortcutSlots.Length; i++)
        {
            shortcutSlots[i].OnRightClickEvent += OnRightClickEvent;
            shortcutSlots[i].OnLeftClickEvent += OnLeftClickEvent;
            //shortcutSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            //shortcutSlots[i].OnEndDragEvent += OnEndDragEvent;
            //shortcutSlots[i].OnDragEvent += OnDragEvent;
            //shortcutSlots[i].OnDropEvent += OnDropEvent;
        }
    }

    private void OnValidate()
    {
        if (shortcutSlotsParent != null)
            shortcutSlots = shortcutSlotsParent.GetComponentsInChildren<ItemSlot>();
    }

    public bool IsFull()
    {
        //return items.Count >= shortcutSlots.Length;
        for (int i = 0; i < shortcutSlots.Length; i++)
        {
            if (shortcutSlots[i].Item == null)
            {
                //previousItem = shortcutSlots[i].Item;
                return false;
            }
        }
        //previousItem = null;
        return true;
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < shortcutSlots.Length; i++)
        {
            if (shortcutSlots[i].Item == null)
            {
                //previousItem = shortcutSlots[i].Item;
                shortcutSlots[i].Item = item;
                return true;
            }
        }
        //previousItem = null;
        return false;
    }

    public bool RemoveItem(Item item)
    {
        for (int i = 0; i < shortcutSlots.Length; i++)
        {
            if (shortcutSlots[i].Item == item)
            {
                //previousItem = shortcutSlots[i].Item;
                shortcutSlots[i].Item = null;
                return true;
            }
        }
        //previousItem = null;
        return false;
    }
    public int CountItem(string itemName)
    {
        int count = 0;
        for (int i = 0; i < shortcutSlots.Length; i++)
        {
            Item item = shortcutSlots[i].Item;
            if (item != null)
            {
                if (item.Name == itemName)
                {
                    count += shortcutSlots[i].Amount;
                }
            }
        }
        return count;
    }

    public void DecreaseOne(int index)
    {
        if(shortcutSlots[index].Item != null)
        {
            if(shortcutSlots[index].Amount > 0)
            {
                shortcutSlots[index].Amount = shortcutSlots[index].Amount - 1;
            }
        }
    }
}
