using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAndAmount
{
    public Item Item;
    [Range(0,99)]
    public int Amount;
}

public enum ItemType {
        Machine,
        Magic,
        Health,
}

[CreateAssetMenu(fileName = "New CraftRecipe", menuName = "VIA2.0/Window Crafting Recipe", order = 0)]
public class WindowCraftingRecipe : ScriptableObject
{
    public List<ItemAndAmount> Materials;
    public ItemAndAmount Result;

    public ItemType type;

    public bool CanCraft(Inventory inventory){
        foreach (ItemAndAmount material in Materials)
        {
            if(!inventory.ContainItem(material.Item, material.Amount)){
                return false;
            }
        }

        if(!inventory.IsFull())
        {
            return true;
        }

        return false;
    }

    public void Craft(Inventory inventory){
        if(CanCraft(inventory)){
            foreach (ItemAndAmount material in Materials)
            {
                //####
                inventory.RemoveItem(material.Item, material.Amount);
            }
            Item itemToAdd = Result.Item.Copy();
            if (!inventory.AddItem(itemToAdd)) {
                //#####
                itemToAdd.Destroy();
            }
        }
    }

}
