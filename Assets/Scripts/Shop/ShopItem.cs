using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ShopItem", menuName = "VIA2.0/ShopItem", order = 0)]
public class ShopItem : ScriptableObject
{
    
    public Item Item;
    [Range(0,99)]
    public int Amount;
    [Range(0,9999)]
    public int Price;

    public bool CanBuy(Inventory inventory){
        return inventory.Money >= Price && Amount > 0 && !inventory.IsFull();
    }

    public void Buy(Inventory inventory){
        if(CanBuy(inventory)){
            inventory.Money = inventory.Money - Price;
            Item itemToAdd = Item.Copy();
            if (!inventory.AddItem(itemToAdd)) {
                itemToAdd.Destroy();
                inventory.Money += Price;
            }
        }
    }
}
